using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MdTools.Entity;
using MdTools.Result;
using Newtonsoft.Json;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace MdTools
{
    public partial class ProdModelAdd : Form
    {
        private delegate void SetPos(int ipos);//代理
        private Thread uploadThread;
        string CurrentDir = "0";
        int PageSize = 20;
        int PageIndex = 1;
        int TotalCount;
        int TotalPage;
        //目录树数据
        public static List<DirItem> DirList;
        public ProdModelAdd()
        {
            InitializeComponent();
        }
        private void ProdModelAdd_Load(object sender, EventArgs e)
        {
            ProdListGrid.AutoGenerateColumns = false;
            ProdListGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GetTree();
            GetDataList("0");
        }
        /// <summary>
        /// 获取目录树
        /// </summary>
        public void GetTree()
        {
            string m_DirUrl = Common.DirApiUrl;
            DirResult m_Result = Http.Instance.HttpGet<DirResult>(m_DirUrl, "", true);
            DirList = m_Result.Data;
            //顶级目录 
            DirItem first = new DirItem() { id = 0, pId = -1, name = "产品目录" };
            TreeNode m_FirstNode = new TreeNode() { Tag = first, Text = first.name, ToolTipText = first.name };
            DirTree.Nodes.Add(m_FirstNode);
            CreateTree(DirList, new DirItem() { id = 0 }, m_FirstNode);
        }


        public void CreateTree(List<DirItem> data, DirItem current, TreeNode currentNode = null)
        {
            var thisLayerData = data.Where(c => c.pId == current.id).ToList();
            if (thisLayerData.Count == 0) return;

            thisLayerData.ForEach(c =>
            {
                if (currentNode == null)
                {
                    var nextNode = new TreeNode() { Tag = c, Text = c.name, ToolTipText = c.name, };
                    Invoke(new Action(() =>
                    {
                        DirTree.Nodes.Add(nextNode);
                    }));
                    CreateTree(data, c, nextNode);
                }
                else
                {
                    var nextNode = new TreeNode() { Tag = c, Text = c.name, ToolTipText = c.name };
                    currentNode.Nodes.Add(nextNode);
                    CreateTree(data, c, nextNode);
                }
            });

            //初次打开型号选择页面   默认打开顶级目录下的产品
            //SelectedExt = new PkgClassExtEntity()
            //{
            //    DataID = 0,
            //    PID = -1,
            //    SPath = "0",
            //    SName = "产品目录"
            //};
            //LoadPkgInfo();

        }


        private void DirTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // MessageBox.Show(JsonConvert.SerializeObject(e.Node.Tag));
            DirItem m_NodeClick = JsonConvert.DeserializeObject<DirItem>(JsonConvert.SerializeObject(e.Node.Tag));
            string DirID = Convert.ToString(m_NodeClick.id);
            this.CurrentDir = DirID;
            this.PageIndex = 1;
            GetDataList(DirID);
        }

        /// <summary>
        /// 获取产品列表
        /// </summary>
        public void GetDataList(string p_DirID)
        {
            try
            {
                this.TipsLabel.Text = "数据加载中...";
                string m_ProdUrl = Common.GetProdUrl + $"?Sid={p_DirID}&pageSize={PageSize}&page={PageIndex}";
                ProdResult m_ProdResult = Http.Instance.HttpGet<ProdResult>(m_ProdUrl, "", true);
                if (m_ProdResult.State == 1 && m_ProdResult.Data.DataRows.Count > 0)
                {
                    this.TotalCount = m_ProdResult.Data.TotalCount;
                    this.TipsLabel.Visible = false;
                    this.ProdListGrid.DataSource = m_ProdResult.Data.DataRows;
                    this.TotalPage = (TotalCount +PageSize-1)/ PageSize;
                    this.PageTips.Text = $"当前第{this.PageIndex}页/共{TotalPage }页";
                }
                else
                {
                    this.PageTips.Text = $"当前第1页";
                    this.ProdListGrid.DataSource = null;
                    this.TipsLabel.Text = "此目录下暂无数据";
                    this.TipsLabel.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 表格按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProdListGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(JsonConvert.SerializeObject(e));
            try
            {
                if (e.ColumnIndex != ProdListGrid.Columns["型号列表"].Index && e.ColumnIndex != ProdListGrid.Columns["操作"].Index)
                {
                    return;
                }

                string m_ProdID = ProdListGrid.Rows[e.RowIndex].Cells[ProdListGrid.Columns["产品ID"].Index].Value.ToString();
                string m_ProdName = ProdListGrid.Rows[e.RowIndex].Cells[ProdListGrid.Columns["产品名称"].Index].Value.ToString();
                if (e.ColumnIndex == ProdListGrid.Columns["型号列表"].Index)
                {
                    ShowModelList(m_ProdID, m_ProdName);
                }
                else
                {
                    ImportModelByProdID(m_ProdID);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// 展示产品型号窗口
        /// </summary>
        /// <param name="p_ProdId"></param>
        public void ShowModelList(string p_ProdId, string p_ProdName)
        {
            new ModelList(p_ProdId, p_ProdName).ShowDialog();

        }

        /// <summary>
        /// 通过产品ID导入型号
        /// </summary>
        /// <param name="p_ProdId"></param>
        public void ImportModelByProdID(string p_ProdId)
        {
            try
            {
                //获取Excel文件名
                string m_FileName = GetFile();
                if (File.Exists(m_FileName))
                {
                    //读取Excel文件
                    List<string> m_ModelList = GetContentFromExcel(m_FileName);
                    m_ModelList = m_ModelList.Distinct().ToList();
                    if (m_ModelList.Count > 0)
                    {
                        UploadModelObject m = new UploadModelObject();
                        m.ModelList = m_ModelList;
                        m.ProdID = p_ProdId;
                        this.progressBar1.Visible = true;
                        this.progressBar1.Value = 0;
                        this.DirTree.Enabled = false;
                        this.ProdListGrid.Enabled = false;
                        this.uploadPro.Visible = true;
                        uploadThread = new Thread(new ParameterizedThreadStart(SaveModelToMd) );
                        uploadThread.IsBackground = true;
                        uploadThread.Start(m);
                    }
                    else
                    {
                        MessageBox.Show("表数据为空, 无法导入");
                    }
                }
            }
            catch (Exception ex)
            {
                this.DirTree.Enabled = true;
                this.ProdListGrid.Enabled = true;
                this.uploadPro.Visible = false;
                throw;
            }
        }

        /// <summary>
        /// 保存型号至迈迪
        /// </summary>
        //private static void SaveModelToMd(List<string> p_ModelList, string p_ProdId)
        public void SaveModelToMd(object p_uploadObject)
        {
            try
            {
                UploadModelObject m_uploadObject = p_uploadObject as UploadModelObject;
                for (int i = 0; i < m_uploadObject.ModelList.Count; i++)   
                {
                    string m_url = Common.SaveModelUrl;
                    ModelToMD m_PostData = new ModelToMD()
                    {
                        ProdID = m_uploadObject.ProdID,
                        Price = "0",
                        SkuName = m_uploadObject.ModelList[i]
                    };
                    BaseResult m_result = Http.Instance.HttpPost<BaseResult>(m_url, JsonConvert.SerializeObject(m_PostData), true);
                    Thread.Sleep(300);
                    SetTextMsg(100 * (i+1 )/ m_uploadObject.ModelList.Count);
                }
                MessageBox.Show("导入型号成功");
            }
            catch (Exception ex)
            {
                this.DirTree.Enabled = true;
                this.ProdListGrid.Enabled = true;
                MessageBox.Show("导入型号失败:" + ex.Message);
                throw;
            }
        }

        //进度条值更新函数（参数必须跟声明的代理参数一样）
        private void SetTextMsg(int ipos)
        {
            if (this.InvokeRequired)   //InvokeRequired属性为真时，说明一个创建它以以外的线程(即SleepT)想访问它
            {
             
                SetPos setpos = new SetPos(SetTextMsg);
                this.Invoke(setpos, new object[] { ipos });//SleepT线程调用本控件Form1中的方法
            }
            else
            {
                this.uploadPro.Text = $"导入进度：{ipos}/100";
                this.progressBar1.Value = Convert.ToInt32(ipos);
                if (this.progressBar1.Value == 100)
                {
                    this.progressBar1.Visible = false;
                    this.progressBar1.Value = 0;
                    this.DirTree.Enabled = true;
                    this.ProdListGrid.Enabled = true;
                    this.uploadPro.Visible = false;
                }
            }
        }

        /// <summary>
        /// 从excel获取内容
        /// </summary>
        /// <param name="p_FileName"></param>
        /// <returns></returns>
        private static List<string> GetContentFromExcel(string p_FileName)
        {
            try
            {
                List<string> m_ContentList = new List<string>();
                if (File.Exists(p_FileName))
                {
                    FileStream m_FileStream = File.OpenRead(p_FileName);
                    NPOI.SS.UserModel.IWorkbook m_Workbook = null;
                    if (p_FileName.IndexOf(".xlsx") > 0)
                    {
                        m_Workbook = new XSSFWorkbook(m_FileStream);
                    }
                    else if (p_FileName.IndexOf(".xls") > 0)
                    {
                        m_Workbook = new HSSFWorkbook(m_FileStream);
                    }
                    //读取第一个工作簿
                    ISheet m_Sheet = m_Workbook.GetSheetAt(0);
                    for (int i = 0; i < m_Sheet.LastRowNum + 1; i++)
                    {
                        //获取当前行数据
                        IRow row = m_Sheet.GetRow(i);
                        //读取当前行第一列数据
                        if (row != null)
                        {
                            ICell cell = row.GetCell(0);
                            if (cell != null)
                            {
                                string m_Model = cell.ToString();
                                m_ContentList.Add(m_Model);
                            }
                        }
                    }
                }
                return m_ContentList;
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        /// <summary>
        /// 文件夹内选择文件
        /// </summary>
        /// <returns></returns>
        private static string GetFile()
        {
            try
            {
                string m_FilePath = string.Empty;
                OpenFileDialog m_DlgOpenFile = new OpenFileDialog();
                m_DlgOpenFile.Title = "FileName";
                //m_DlgOpenFile.InitialDirectory = @"桌面";
                m_DlgOpenFile.Filter = ".xlsx | *.xls;";
                m_DlgOpenFile.FilterIndex = 1;

                DialogResult m_Dr = m_DlgOpenFile.ShowDialog();

                if (m_Dr == DialogResult.OK)
                {
                    m_FilePath = m_DlgOpenFile.FileName;
                }
                else
                {
                    m_FilePath = "";
                }
                return m_FilePath;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 上一页点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LastPage_Click(object sender, EventArgs e)
        {
            if (PageIndex>1)
            {
                PageIndex--;
                GetDataList(CurrentDir);
            }
            else
            {
                MessageBox.Show("当前已是首页");
            }
        }

        /// <summary>
        /// 下一页点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextPage_Click(object sender, EventArgs e)
        {
            if (PageIndex<TotalPage)
            {
                PageIndex++;
                GetDataList(CurrentDir);
            }
            else
            {
                MessageBox.Show("当前已是末页");
            }

        }
    }

    /// <summary>
    /// 上传型号至迈迪类
    /// </summary>
    public class UploadModelObject
    {
        public List<string> ModelList;
        public string ProdID;
    }
}
