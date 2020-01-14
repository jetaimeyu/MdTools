using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace MdTools
{
    public partial class FormGetRedCode : Form
    {
        public FormGetRedCode()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 领取按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetRedCodeButton_Click(object sender, EventArgs e)
        {
            try
            {
                StatusChange(false);
                if (string.IsNullOrEmpty(CodeCount.Text))
                {
                    MessageBox.Show("请输入领用数量");
                    return;
                }
                int m_Count = int.Parse(CodeCount.Text);
                string m_Url = $"http://api45.maidiyun.com/api/v2/GuiLinGuoJi/ReqRedPacketCode?num={Convert.ToString(m_Count)}";
                string m_FileName = GetFile();
                Http.downfile(m_Url, m_FileName);
                StatusChange(true);
                MessageBox.Show("领用成功");
            }
            catch (Exception ex)
            {
                StatusChange(true);
                MessageBox.Show(ex.Message);
                return;
            }
        }

        /// <summary>
        ///  领用状态切换
        /// </summary>
        /// <param name="status"></param>
        private void StatusChange(bool status)
        {
            GetRedCodeButton.Enabled = status;
            CodeCount.Enabled = status;
            if (status)
            {
                label2.Text = "领码时尽量少量多次，推荐一次领一万个";
            }
            else
            {
                label2.Text = "领取中，请稍候！";
            }
        }


        /// <summary>
        /// 文件夹文件保存位置
        /// </summary>
        /// <returns></returns>
        private static string GetFile()
        {
            try
            {
                string localFilePath = "";
                //string localFilePath, fileNameExt, newFileName, FilePath; 
                SaveFileDialog sfd = new SaveFileDialog();
                //设置文件类型 
                sfd.Filter = "Excel表格（*.xlsx）|*.xls";

                //设置默认文件类型显示顺序 
                sfd.FilterIndex = 1;

                //保存对话框是否记忆上次打开的目录 
                sfd.RestoreDirectory = true;

                //点了保存按钮进入 
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    localFilePath = sfd.FileName.ToString(); //获得文件路径 
                    string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径

                    //获取文件路径，不带文件名 
                    //FilePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\")); 

                    //给文件名前加上时间 
                    //newFileName = DateTime.Now.ToString("yyyyMMdd") + fileNameExt; 

                    //在文件名里加字符 
                    //saveFileDialog1.FileName.Insert(1,"dameng"); 

                    //System.IO.FileStream fs = (System.IO.FileStream)sfd.OpenFile();//输出文件 

                    ////fs输出带文字或图片的文件，就看需求了 
                }

                return localFilePath;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MyLog.ILog.Error("日志Error");
                MyLog.ILog.Warn("日志Warn");
                MyLog.ILog.Info("日志Info");
                MyLog.ILog.Debug("日志Debug");
            

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
