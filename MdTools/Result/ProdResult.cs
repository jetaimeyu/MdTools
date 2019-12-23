using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MdTools.Result
{
    public class ProdResult:BaseResult
    {
        public new DataResult Data;
    }
    public class DataResult
    {
        public new List<ProdItem> DataRows;
        public int TotalCount { set; get; }
    }
    public class ProdItem
    {
        public string ProdID { set; get; }
        public string ProdName { set; get; }
        public string PromoteName { set; get; }
        public string IsNew { set; get; }
        public int SourceType { set; get; }
        public int SID { set; get; }
        public string SPath { set; get; }
    }
}
