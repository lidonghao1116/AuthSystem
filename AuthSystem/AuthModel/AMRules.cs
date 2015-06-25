using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuthSystem.AuthModel
{
    public class AMRule:AMBase
    {
        public AMRule() { }

        private string _Rule_ID = "";
        public string Rule_ID
        {
            get { return _Rule_ID; }
            set { _Rule_ID = value; }
        }

        private string _Rule_Name = "";
        public string Rule_Name
        {
            get { return _Rule_Name; }
            set { _Rule_Name = value; }
        }

        private string _Rule_Item_ID = "";
        public string Rule_Item_ID
        {
            get { return _Rule_Item_ID; }
            set { _Rule_Item_ID = value; }
        }

        private string _Rule_Up_RuleID = "";
        public string Rule_Up_RuleID
        {
            get { return _Rule_Up_RuleID; }
            set { _Rule_Up_RuleID = value; }
        }

        private string _Rule_BeiZhu = "";
        public string Rule_BeiZhu
        {
            get { return _Rule_BeiZhu; }
            set { _Rule_BeiZhu = value; }
        }
    }
}
