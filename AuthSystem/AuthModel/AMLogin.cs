using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuthSystem.AuthModel
{
    /// <summary>
    /// 登陆检测类的Model
    /// </summary>
    /// 
    public class AMLogin:AMBase
    {
        public AMLogin()
        {
            //TODO：初始化
        }
        private string _Name=""; //登陆用户名---------------------------
        /// <summary>
        /// 登陆的用户名
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _PassWord = "";//登陆密码-------------------------
        /// <summary>
        /// 登陆的密码
        /// </summary>
        public string PassWord
        {
            get { return _PassWord; }
            set { _PassWord = value; }
        }
        private string _AuthGroup = "";//所属权限组----------------------
        /// <summary>
        /// 所属的权限组
        /// </summary>
        public string AuthGroup
        {
            get { return _AuthGroup; }
            set { _AuthGroup = value; }
        }
        private string _CangKu = "";//默认的仓库-------------------------
        /// <summary>
        /// 有权限的仓库，第一个为默认仓库
        /// </summary>
        public string CangKu
        {
            get { return _CangKu; }
            set { _CangKu = value; }
        }
        private string _Other = "";//其它数据----------------------------
        /// <summary>
        /// 未定义的其它信息
        /// </summary>
        public string Other
        {
            get { return _Other; }
            set { _Other = value; }
        }
        private bool _nameCanEmail = false;//用户名是否可以有@和.符号---------
        /// <summary>
        /// 用户名是否可以有@和.符号
        /// </summary>
        public bool nameCanEmail
        {
            get { return _nameCanEmail; }
            set { _nameCanEmail = value; }
        }

    }
}
