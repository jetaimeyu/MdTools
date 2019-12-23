using System;
using System.Collections.Generic;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Login());
            //Application.Run(new Form1());
            if (new Login().ShowDialog() == DialogResult.OK)
            {
                Application.Run(new ProdModelAdd());
            }
        }
    }
}
