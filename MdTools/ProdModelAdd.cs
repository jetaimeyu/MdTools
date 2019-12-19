using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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

        int TotalPage = 1;
        int PageSize = 50;
        int PageIndex = 1;
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
            GetDataList(DirID);
        }

        /// <summary>
        /// 获取产品列表
        /// </summary>
        public void GetDataList(string p_DirID, int pageIndex = 1, int pageSize = 50)
        {
            try
            {
                this.TipsLabel.Text = "数据加载中...";
                string m_ProdUrl = Common.GetProdUrl + $"?Sid={p_DirID}&pageSize={pageSize}&page={pageIndex}";
                ProdResult m_ProdResult = Http.Instance.HttpGet<ProdResult>(m_ProdUrl, "", true);
                if (m_ProdResult.State == 1 && m_ProdResult.Data.DataRows.Count > 0)
                {
                    this.TipsLabel.Visible = false;
                    this.ProdListGrid.DataSource = m_ProdResult.Data.DataRows;
                    //无需显示的列
                    //ProdListGrid.Columns["PromoteName"].Visible = false;
                    //ProdListGrid.Columns["IsNew"].Visible = false;
                    //ProdListGrid.Columns["SourceType"].Visible = false;
                    //ProdListGrid.Columns["SID"].Visible = false;
                    //ProdListGrid.Columns["SPath"].Visible = false;
                }
                else
                {
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

        private void ProdListGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(JsonConvert.SerializeObject(e));

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_ProdId"></param>
        public void ShowModelList(string p_ProdId, string p_ProdName)
        {
            new ModelList(p_ProdId, p_ProdName).ShowDialog();

        }

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
                        SaveModelToMd(m_ModelList, p_ProdId);
                    }
                    else
                    {
                        MessageBox.Show("表数据为空, 无法导入");
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
           


        }
        /// <summary>
        /// 保存型号至迈迪
        /// </summary>
        private static void SaveModelToMd(List<string> p_ModelList, string p_ProdId)
        {
            try
            {
                foreach (var item in p_ModelList)
                {
                    string m_url = Common.SaveModelUrl;
                    ModelToMD m_PostData = new ModelToMD()
                    {
                        ProdID = p_ProdId,
                        Price = "0",
                        SkuName = item
                    };
                    BaseResult m_result = Http.Instance.HttpPost<BaseResult>(m_url, JsonConvert.SerializeObject(m_PostData), true);

                }
                MessageBox.Show("导入型号成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("导入型号失败:" + ex.Message);
                throw;
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
                    for (int i = 0; i < m_Sheet.LastRowNum+1; i++)
                    {
                        //获取当前行数据
                        IRow row = m_Sheet.GetRow(i);
                        //读取当前行第一列数据
                        if (row!=null)
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
            catch (Exception ex )
            {

                throw;
            }


        }

        /// <summary>
        /// 文件夹内选择文件
        /// </summary>
        /// <returns></returns>
        private static string  GetFile()
        {
            try
            {
                string m_FilePath = string.Empty;
                OpenFileDialog m_DlgOpenFile = new OpenFileDialog();
                m_DlgOpenFile.Title = "FileName";
                m_DlgOpenFile.InitialDirectory = @"E:\";
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
    }
}
