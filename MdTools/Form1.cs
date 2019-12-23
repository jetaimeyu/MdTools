using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MdTools
{
    public partial class Form1 : Form
    {
        private delegate void SetPros(int ipos); //定义一个委托


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.backgroundWorker1.RunWorkerAsync();  //运行backgroundWorker组件
            ProgressForm form = new ProgressForm(this.backgroundWorker1);  //显示进度条窗体
            form.ShowDialog(this);
            form.Close();
            // Thread m_Thread=ThreadStart
            //Thread ss = new Thread(new ParameterizedThreadStart(backgroundWorker1_DoWork));
        }


        //在另一个线程上开始运行(处理进度条)
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            for (int i = 0; i < 100; i++)
            {
                System.Threading.Thread.Sleep(100);
                worker.ReportProgress(i);
                if (worker.CancellationPending) //获取程序是否已请求取消后台操作
                {
                    e.Cancel = true;
                    break;
                }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("取消");
            }
            else
            {
                MessageBox.Show("完成");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.listBox1.Text = "333";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Thread ss = new Thread(DoWorks);
            Thread ss = new Thread(DoWorks);
            ss.Start();

        }

        private void DoWorks()
        {

            for (int i = 0; i < 500; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine(i);
                //Console.WriteLine(100 * i / 500);
                 //SetProgressValue(Convert.ToInt32(100*i /500));
                SetProgressValue(Convert.ToInt32(i/500*100));
            }

        }

        private void SetProgressValue(int p_Pos)
        {

            if (this.InvokeRequired)
            {
                SetPros m_SetPros = new SetPros(SetProgressValue);
                this.Invoke(m_SetPros, new object[] { p_Pos });
            }
            else
            {
                this.progressBar1.Value= p_Pos;
            }
        }
    }
}
