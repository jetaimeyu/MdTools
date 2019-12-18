using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MdTools.Result
{
    public class UserResult:BaseResult
    {
        public new UserModel[] Data;
    }

    public class UserModel
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// 用户的所在部门编号
        /// </summary>
        public int OrgID { get; set; }

        /// <summary>
        /// 用户的所在部门名
        /// </summary>
        public string OrgName { get; set; }

        /// <summary>
        /// 所属维修点编号
        /// </summary>
        public int AsID { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 盐
        /// </summary>
        public string Salt { get; set; }

        /// <summary>
        /// 用户类型：1个人 2企业
        /// </summary>
        public string UserType { get; set; }

        /// <summary>
        /// 用户昵称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户的所在企业编号
        /// </summary>
        public int CompID { get; set; }

        /// <summary>
        /// 用户所在企业的通号
        /// </summary>
        public string CompMdt { get; set; }

        /// <summary>
        /// 用户的单位名称
        /// </summary>
        public string CompName { get; set; }

        /// <summary>
        /// 用户通号
        /// </summary>
        public string Mdt { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 公开名称
        /// </summary>
        public string PublicName { get; set; }

        /// <summary>
        /// 公开状态：0不公开 1公开
        /// </summary>
        public string PublicState { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string IDCard { get; set; }

        /// <summary>
        /// 性别：1男 2女
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 用户联系电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 用户固定电话
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 用户的电子邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 职务
        /// </summary>
        public string Duty { get; set; }

        /// <summary>
        /// 状态：0注册 1认证中 2已认证 3交费(VIP) 4超级VIP 8禁用 9删除
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 区
        /// </summary>
        public string District { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 注册日期
        /// </summary>
        public string RegDate { get; set; }

        /// <summary>
        /// 注册人
        /// </summary>
        public int RegUser { get; set; }

        /// <summary>
        /// 注册IP
        /// </summary>
        public string RegIP { get; set; }

        /// <summary>
        /// 推送标识
        /// </summary>
        public string PushClientID { get; set; }

        /// <summary>
        /// 0 未实名认证 1已认证
        /// </summary>
        public string IsAUT { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PwdState { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? LastLoginDate { get; set; }

        /// <summary>
        /// 是否部门领导
        /// </summary>
        public string IsDeptLeader { get; set; }

        /// <summary>
        /// 所属部门主管名称
        /// </summary>
        public string LeaderName { get; set; }

        /// <summary>
        /// 所属部门主管ID
        /// </summary>
        public int DeptLeader { get; set; }

        /// <summary>
        /// 创建人ID
        /// </summary>
        public int? CreateUserID { get; set; }

        public DateTime? CreateDate { get; set; }


        /// <summary>
        /// 是否企业创始人0 不是，1 是
        /// </summary>
        public string IsCompCreater { get; set; }

        public string Token { get; set; }

    }
}
