using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuthSystem.AuthModel
{
    public class AMMenu:AMBase
    {
        public AMMenu() { }

        private string _Menu_ID = "";
        public string Menu_ID
        {
            get { return _Menu_ID; }
            set { _Menu_ID = value; }
        }

        private string _Menu_Name = "";
        public string Menu_Name
        {
            get { return _Menu_Name; }
            set { _Menu_Name = value; }
        }

        private string _Menu_UpItemID = "";
        public string Menu_UpItemID
        {
            get { return _Menu_UpItemID; }
            set { _Menu_UpItemID = value; }
        }

        private string _Menu_BeiZhu = "";
        public string Menu_BeiZhu
        {
            get { return _Menu_BeiZhu; }
            set { _Menu_BeiZhu = value; }
        }
    }
}
