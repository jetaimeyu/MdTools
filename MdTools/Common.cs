using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using MdTools.Result;

namespace MdTools
{
    class Common
    {

        public static UserModel user;

        // http://www.maidiyun.com/
        public static string WebApi = ConfigurationManager.AppSettings["WebApi"];


        //string url = Common.ApiUrlLogin + "?userId=" + userName + "&password=" + userPass;
        //string url = "http://api50.maidiyun.com/api/v1/User/Login?userId=" + userName + "&password=" + userPass;
        //迈迪登录
        public static string ApiUrlLogin = WebApi + "/50/api/v1/User/Login";

        //http://api45.maidiyun.com/api/v1/Prod/GetPkgClassExt?DirType=&v=0.7236976369749755&_=1576574057474
        //获取产品目录
        public static string DirApiUrl = WebApi + "/45/api/v1/Prod/GetPkgClassExt";



    }
}
