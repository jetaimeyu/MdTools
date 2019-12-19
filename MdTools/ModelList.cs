using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MdTools.Result;

namespace MdTools
{
    public partial class ModelList : Form
    {
        //产品ID
        private string m_ProdID;
        //产品名称
        private string m_ProdName;

        public ModelList(string p_ProdID, string p_ProdName)
        {
            this.m_ProdID = p_ProdID;
            this.m_ProdName = p_ProdName;
            InitializeComponent();
        }

        private void ModelList_Load(object sender, EventArgs e)
        {
            this.Text = m_ProdName;
            ModelListGridView.AutoGenerateColumns = false;
            ModelListGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.GetModelListByProdID();
        }
        /// <summary>
        /// 通过产品ID获取型号列表
        /// </summary>
        private void GetModelListByProdID()
        {
            try
            {
                this.TipsLabel.Text = "数据加载中...";
                string m_url = Common.ModelListUrl + $"?prodId={m_ProdID}";
                ModelListResult m_Resulut = Http.Instance.HttpGet<ModelListResult>(m_url, "", true);
                if (m_Resulut.State == 1)
                {
                    if (m_Resulut.Data.Count > 0)
                    {
                        this.TipsLabel.Visible = false;
                        ModelListGridView.DataSource = m_Resulut.Data;
                    }
                    else
                    {
                        ModelListGridView.DataSource = null;
                        this.TipsLabel.Text = "此产品暂无型号数据";
                        this.TipsLabel.Visible = true;
                    }
                }
                else
                {
                    this.TipsLabel.Visible = false;
                    MessageBox.Show("型号列表请求失败！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        /// <summary>
        /// 按Esc键关闭窗体
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            int WM_KEYDOWN = 256;
            int WM_SYSKEYDOWN = 260;
            if (msg.Msg == WM_KEYDOWN | msg.Msg == WM_SYSKEYDOWN)
            {
                switch (keyData)
                {
                    case Keys.Escape:
                        this.Close();//esc关闭窗体
                        break;
                }
            }
            return false;
        }
    }
}
