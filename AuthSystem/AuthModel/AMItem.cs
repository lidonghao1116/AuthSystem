using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuthSystem.AuthModel
{
    public class AMItem:AMBase
    {
        public AMItem() { }

        private string _Item_ID = "";
        public string Item_ID
        {
            get { return _Item_ID; }
            set { _Item_ID = value; }
        }

        private string _Item_Name = "";
        public string Item_Name
        {
            get { return _Item_Name; }
            set { _Item_Name = value; }
        }

        private string _Item_NameSpace = "";
        public string Item_NameSpace
        {
            get { return _Item_NameSpace; }
            set { _Item_NameSpace = value; }
        }

        private string _Item_BeiZhu = "";
        public string Item_BeiZhu
        {
            get { return _Item_BeiZhu; }
            set { _Item_BeiZhu = value; }
        }
    }

    public enum AMItemValueType
    {
        Item_ID,
        Item_Name,
        Item_NameSpace,
        Item_BeiZhu
    }
}
