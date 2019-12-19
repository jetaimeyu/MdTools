using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class Login : Form
    {
        public Login()
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
            if (System.IO.File.Exists(Application.StartupPath + "\\username.txt")){
                string tbUserRe = System.IO.File.ReadAllText(Application.StartupPath + "\\username.txt");
                tbUser.Text = tbUserRe;
            }
            if (System.IO.File.Exists(Application.StartupPath + "\\password.txt"))
            {
                string txtPassWordRe = System.IO.File.ReadAllText(Application.StartupPath + "\\password.txt");
                txtPassWord.Text = txtPassWordRe;
            }
        }
    }
}
