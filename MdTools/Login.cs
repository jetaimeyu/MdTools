using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MdTools.Result;
using static System.Net.WebRequestMethods;

namespace MdTools
{
    public partial class 登录 : Form
    {
        public 登录()
        {
            InitializeComponent();
            string ss = Application.ProductVersion;
            lbVersion.Text = "V " + Application.ProductVersion;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            string userName = tbUser.Text.Trim();
            string userPass = txtPassWord.Text;
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(userPass))
            {
                MessageBox.Show("用户名或密码不能为空！", "登录", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnLogin.Enabled = true;
                return;
            }
            Task.Factory.StartNew(() =>
            {
                int state = LoginOnline(userName, userPass);
                if (state == 1)
                {
                    Invoke(new Action(() =>
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }));
                }

            });
            btnLogin.Enabled = true;
        }


        private int LoginOnline(string userName, string userPass)
        {
            try
            {
                string url = Common.ApiUrlLogin + "?userId=" + userName + "&password=" + userPass;
                //string url = "http://api50.maidiyun.com/api/v1/User/Login?userId=" + userName + "&password=" + userPass;
                UserResult res = Http.Instance.HttpGet<UserResult>(url, "");
                if (res.State <= 0)
                {
                    MessageBox.Show("登录失败," + res.ErrorMessage, "登录", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return 0;
                }
                if (chbIsRemember.Checked == true)
                {

                    StreamWriter sw = new StreamWriter(Application.StartupPath + "\\username.txt", false);
                    sw.WriteLine(userName);
                    sw.Close();//写入
                    StreamWriter swp = new StreamWriter(Application.StartupPath + "\\password.txt", false);
                    swp.WriteLine(userPass);
                    swp.Close();//写入

                }

                Common.user = res.Data[0];
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"登陆报错，错误是：" + ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return 2;
        }

        private void chbIsRemember_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            tbUser.Text = "";
            txtPassWord.Text = "";
            StreamWriter sw = new StreamWriter(Application.StartupPath + "\\username.txt", false);
            sw.WriteLine("");
            sw.Close();//写入
            StreamWriter swp = new StreamWriter(Application.StartupPath + "\\password.txt", false);
            swp.WriteLine("");
            swp.Close();//写入
        }

        private void lbVersion_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(Application.StartupPath + "\\username.txt"))
            {
                string tbUserRe = System.IO.File.ReadAllText(Application.StartupPath + "\\username.txt");
                tbUser.Text = tbUserRe;
            }
            if (System.IO.File.Exists(Application.StartupPath + "\\password.txt"))
            {
                string txtPassWordRe = System.IO.File.ReadAllText(Application.StartupPath + "\\password.txt");
                txtPassWord.Text = txtPassWordRe;
            }


            //string StartPath = Application.StartupPath;
            //if (!Directory.Exists(StartPath + "\\db"))
            //    Directory.CreateDirectory(StartPath + "\\db");
            //var fileName = StartPath + "/db/data.db";

            //SQLiteConnection.CreateFile(fileName);
            //MakeRedCode();
        }


        /// <summary>
        /// 生成红包码
        /// </summary>
        private void MakeRedCode()
        {
            string m_sql = "insert into RedCode (RelationCode, RedCode)values(";

            for (int i = 0; i < 50; i++)
            {
                m_sql += $"'{ GetNewGuidLong()}','https://m.maidiyun.com/?HB:{GetNewGuidLong()}'),(";
            }
            string ss = m_sql.Remove(m_sql.Length-2, 2);

            //SQLiteCommand dbCommand = new SQLiteCommand();
            //dbCommand.CommandText = ss;
            SQLiteHelper.ExecuteNonQuery(SQLiteHelper.LocalDbConnectionString , ss, CommandType.Text);
        }


        /// <summary>
        /// 获取一个新的GUID转uLong
        /// </summary>
        /// <returns></returns>
        public static long GetNewGuidLong()
        {
            return BitConverter.ToInt64(Guid.NewGuid().ToByteArray(), 0);
        }

    }
}
