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
    public partial class FrmFillCode : Form
    {
        public FrmFillCode()
        {
            InitializeComponent();
        }

        private void DownCodeButton_Click(object sender, EventArgs e)
        {
            string m_DirUrl = Common.FillCodeUrl+ "?quantity=" + DownCount.Text + "&compId=" + CompID.Text;
            BaseResult result = Http.Instance.HttpGet<BaseResult>(m_DirUrl, "", true);
            if (result.State == 1)
            {
                MessageBox.Show(result.Data);
            }
            else
            {
                MessageBox.Show(result.ErrorMessage);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string m_DirUrl = Common.FillCodeCountUrl + "?compId=" + CompID.Text;
            BaseResult result = Http.Instance.HttpGet<BaseResult>(m_DirUrl, "", true);
            if (result.State == 1)
            {
                MessageBox.Show(Convert.ToString(result.Data));
            }
            else
            {
                MessageBox.Show(result.ErrorMessage);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string m_DirUrl = Common.FillCodeCountUrl + "?compId=" + CompID.Text;
            BaseResult result = Http.Instance.HttpGet<BaseResult>(m_DirUrl, "", true);
            if (result.State == 1)
            {
                MessageBox.Show("获取成功");
                currentCount.Text = Convert.ToString(result.Data) ;
            }
            else
            {
                MessageBox.Show(result.ErrorMessage);
            }

        }
    }
}
