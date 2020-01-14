using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MdTools
{
    public partial class FormScanCode : Form
    {

        /// <summary>
        /// 扫码socket
        /// </summary>
        Socket ScanSocketWatch;

        /// <summary>
        /// 标志是否开启
        /// </summary>
        bool IsStart;

        public FormScanCode()
        {
            InitializeComponent();
        }

        private void Scan_TextChanged(object sender, EventArgs e)
        {

        }

        private void ScanStart_Click(object sender, EventArgs e)
        {
            try
            {
                string m_IP = ScanIP.Text.Trim();
                if (string.IsNullOrEmpty(m_IP))
                {
                    MessageBox.Show("请先填写IP地址");
                    return;
                }
                if (SocketListen())
                {
                    Tips.Text = "正在扫码";
                    ScanStart.Enabled = false;
                    ScanStop.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private bool SocketListen()
        {
            try
            {
                if (ScanSocketWatch == null || !ScanSocketWatch.Connected)
                {
                    IPAddress m_ScanIP = IPAddress.Parse(ScanIP.Text.Trim());
                    IPEndPoint m_ScanPoint = new IPEndPoint(m_ScanIP, Convert.ToInt32(ScanPoint.Text));
                    ScanSocketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    ScanSocketWatch.Connect(m_ScanPoint);
                    ScanSocketWatch.Send(Encoding.UTF8.GetBytes("start"));
                    IsStart = true; //物联码扫描设备需关闭这变量赋值
                    Task.Factory.StartNew(() =>
                    {
                        while (IsStart)
                        {
                            if (!ScanSocketWatch.Connected)
                            {
                                break;
                            }

                            //客户端连接成功后，服务器应该接受客户端发来的消息
                            byte[] buffer = new byte[1024 * 1024 * 2];
                            //实际接受到的有效字节数
                            int r = ScanSocketWatch.Receive(buffer);
                            if (r == 0)
                            {
                                continue;
                            }
                            string str = Encoding.UTF8.GetString(buffer, 0, r).Trim();
                            if (str == "NoData" || str == "\u0002\u0018")
                            {
                                Invoke(new Action(() =>
                                {
                                    ScanList.Items.Add("物联码设备本次未扫到物联码");
                                }));
                                continue;
                            }
                            Invoke(new Action(() =>
                            {
                                ScanList.Items.Add(str);
                            }));
                        }
                    });
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

        private void FormScanCode_Load(object sender, EventArgs e)
        {

        }

        private void ScanStop_Click(object sender, EventArgs e)
        {
            try
            {
                ScanSocketWatch.Send(Encoding.UTF8.GetBytes("stop"));
                IsStart = false;
                ScanSocketWatch.Disconnect(false);
                ScanStart.Enabled = true;
                ScanStop.Enabled = false;
                Tips.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
