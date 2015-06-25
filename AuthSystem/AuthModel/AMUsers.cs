using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuthSystem.AuthModel
{
    /// <summary>
    /// 单个用户对象
    /// </summary>
    public class AMUser : AMBase
    {
        public AMUser() { }

        private string _User_ID = "";
        public string User_ID
        {
            get { return _User_ID; }
            set { _User_ID = value; }
        }

        private string _User_Name = "";
        public string User_Name
        {
            get { return _User_Name; }
            set { _User_Name = value; }
        }

        private string _User_Text = "";
        public string User_Text
        {
            get { return _User_Text; }
            set { _User_Text = value; }
        }

        private string _User_Pass = "";
        public string User_Pass
        {
            get { return _User_Pass; }
            set { _User_Pass = value; }
        }

        private string _User_Tel = "";
        public string User_Tel
        {
            get { return _User_Tel; }
            set { _User_Tel = value; }
        }

        private string _User_QQ = "";
        public string User_QQ
        {
            get { return _User_QQ; }
            set { _User_QQ = value; }
        }

        private string _User_Email = "";
        public string User_Email
        {
            get { return _User_Email; }
            set { _User_Email = value; }
        }

        private bool _User_Status = false;
        public bool User_Status
        {
            get { return _User_Status; }
            set { _User_Status = value; }
        }

        private string _User_Group = "";
        public string User_Group
        {
            get { return _User_Group; }
            set { _User_Group = value; }
        }

        private string _User_CangKu = "";
        public string User_CangKu
        {
            get { return _User_CangKu; }
            set { _User_CangKu = value; }
        }

        private string _User_BeiZhu = "";
        public string User_BeiZhu
        {
            get { return _User_BeiZhu; }
            set { _User_BeiZhu = value; }
        }
    }
}
