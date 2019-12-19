using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MdTools.Result
{
    public class ModelListResult:BaseResult
    {
        public new List<ModelEntity> Data;
    }
    public class ModelEntity
    {
        public string SkuID { set; get; }
        public string SkuName { set; get; }

    }
}
