using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MdTools.Result
{
    public class BaseResult
    {
        /// <summary>
        /// 返回值状态，小于等于0失败，大于等于1成功
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 返回值内容
        /// </summary>
        public dynamic Data { get; set; }

        /// <summary>
        /// 错误描述
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
