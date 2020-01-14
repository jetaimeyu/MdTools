using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MdTools
{
    public class MyLog
    {
        public static log4net.ILog ILog = log4net.LogManager.GetLogger("MdTools.Logging");

        public MyLog()
        {

        }

        public static void WriteInfo(string message)
        {
            ILog.Info(message);
        }

        public static void WriteError(string message)
        {
            ILog.Error(message);
        }


        public static void WriteDebug(string message)
        {
            ILog.Debug(message);
        }
    }
}
