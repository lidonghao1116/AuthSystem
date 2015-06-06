﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuthSystem.AuthModel
{
    /// <summary>
    /// 登陆检测类的Model
    /// </summary>
    /// 
    [NonSerialized]
    public class AMLogin:AMBase
    {
        private string _Name=""; //登陆用户名----------------------
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _PassWord = "";//登陆密码----------------------
        public string PassWord
        {
            get { return _PassWord; }
            set { _PassWord = value; }
        }
        private string _AuthGroup = "";//所属权限组----------------------
        public string AuthGroup
        {
            get { return _AuthGroup; }
            set { _AuthGroup = value; }
        }
        private string _CangKu = "";//默认的仓库----------------------
        public string CangKu
        {
            get { return _CangKu; }
            set { _CangKu = value; }
        }
        private string _Other = "";//其它数据----------------------
        public string Other
        {
            get { return _Other; }
            set { _Other = value; }
        }
    }
}