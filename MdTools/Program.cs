using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MdTools
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo("log4net.config"));
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (new 登录().ShowDialog() == DialogResult.OK)
            {
                Application.Run(new FormGetRedCode());
            }
                //Application.Run(new Login());
                //Application.Run(new Form1());
             //   Application.Run(new FormScanCode());
            //if (new Login().ShowDialog() == DialogResult.OK)
            //{
            //    Application.Run(new ProdModelAdd());
            //}
        }
    }
}
