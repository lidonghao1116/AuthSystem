using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuthSystem.AuthModel
{
    #region 所有用户对象定义----------------------------------------------------------------------------------------
    /// <summary>
    /// 所有用户对象
    /// </summary>
    public class AMUsers:AMBase
    {
        public AMUsers()
        {
            //Init
        }
        private List<AMUser> _ListAMUsers;
        public bool Add(AMUser amu)
        {
            _ListAMUsers.Add(amu);
            return true;
        }
        public bool Del(AMUser amu)
        {
            _ListAMUsers.Remove(amu);
            return true;
        }
        public List<AMUser> ListAMUsers
        {
            get { return _ListAMUsers; }
            set { _ListAMUsers = value; }
        }

    }
    #endregion
    #region 单个用户对象定义----------------------------------------------------------------------------------------
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
            get { return _User_ID; }
            set { _User_ID = value; }
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

        private string _User_Phone = "";
        public string User_Phone
        {
            get { return _User_Phone; }
            set { _User_Phone = value; }
        }

        private string _User_Email = "";
        public string User_Email
        {
            get { return _User_Email; }
            set { _User_Email = value; }
        }

        private string _User_QQ = "";
        public string User_QQ
        {
            get { return _User_QQ; }
            set { _User_QQ = value; }
        }
    }
    #endregion
}
