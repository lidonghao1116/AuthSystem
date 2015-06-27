using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuthSystem.AuthModel
{
    public class AMX2Y:AMBase
    {
        public AMX2Y() { }

        private string _ID1 = "";
        public string ID1
        {
            get { return _ID1; }
            set { _ID1 = value; }
        }

        private string _ID2 = "";
        public string ID2
        {
            get { return _ID2; }
            set { _ID2 = value; }
        }
    }
}
