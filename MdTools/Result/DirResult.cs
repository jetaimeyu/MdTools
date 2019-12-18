using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MdTools.Result
{
    public class DirResult:BaseResult
    {
        public  new List<DirItem> Data;
    }

    public class DirItem
    {
        public string SPath { set; get; }
        public int SortID { set; get;}
        public int id { set; get; }
        public string name { set; get; }
        public int pId { set; get; }
    }
}
