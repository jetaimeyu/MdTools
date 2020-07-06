using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using MdTools.Result;

namespace MdTools
{
    public class Common
    {

        public static UserModel user;

        public static string WebApi = ConfigurationManager.AppSettings["WebApi"];

        //迈迪登录
        public static string ApiUrlLogin = WebApi + "/50/api/v1/User/Login";

        //获取产品目录
        public static string DirApiUrl = WebApi + "/45/api/v1/Prod/GetPkgClassExt";

        //获取产品列表接口
        public static string GetProdUrl = WebApi + "/45/api/v1/Prod/GetPkgNameList";

        //保存型号至迈迪 
        public static string SaveModelUrl = WebApi + "/45/api/v1.1/Prod/SaveSkuForCode";

        //型号列表
        public static string ModelListUrl = WebApi + "/50/api/v1/Prod/GetWeiXinDzSkuListByProId";


        //http://192.168.1.51:8001/api/v1/Comp/CompCacheCode
        //码池填充
        public static string FillCodeUrl = ConfigurationManager.AppSettings["WebApiCode"] + "/api/v1/Comp/CompCacheCode";
        public static string FillCodeCountUrl = ConfigurationManager.AppSettings["WebApiCode"] + "/api/v1/Comp/GetCompCacheCodeCount";

    }
}
