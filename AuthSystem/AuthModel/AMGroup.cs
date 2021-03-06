﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuthSystem.AuthModel
{
    public class AMGroup : AMBase
    {
        public AMGroup()
        {
            //TODO
        }

        private string _Group_ID = "";
        public string Group_ID
        {
            get { return _Group_ID; }
            set { _Group_ID = value; }
        }

        private string _Group_Name = "";
        public string Group_Name
        {
            get { return _Group_Name; }
            set { _Group_Name = value; }
        }

        private bool _Group_Status = false;
        public bool Group_Status
        {
            get { return _Group_Status; }
            set { _Group_Status = value; }
        }

        private string _Group_Rule_ID = "";
        public string Group_Rule_ID
        {
            get { return _Group_Rule_ID; }
            set { _Group_Rule_ID = value; }
        }

        private string _Group_CangKu_ID = "";
        public string Group_CangKu_ID
        {
            get { return _Group_CangKu_ID; }
            set { _Group_CangKu_ID = value; }
        }

        private string _Group_Menu_ID = "";
        public string Group_Menu_ID
        {
            get { return _Group_Menu_ID; }
            set { _Group_Menu_ID = value; }
        }

        private string _Group_BeiZhu = "";
        public string Group_BeiZhu
        {
            get { return _Group_BeiZhu; }
            set { _Group_BeiZhu = value; }
        }

    }
}
