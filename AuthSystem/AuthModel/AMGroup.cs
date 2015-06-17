using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuthSystem.AuthModel
{
    public class AMGroup:AMBase
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

        private string _Group_GroupRuleID = "";
        public string Group_GroupRuleID
        {
            get { return _Group_GroupRuleID; }
            set { _Group_GroupRuleID = value; }
        }

        private bool _Group_Status = false;
        public bool Group_Status
        {
            get { return _Group_Status; }
            set { _Group_Status = value; }
        }

        private string _Group_BeiZhu = "";
        public string Group_BeiZhu
        {
            get { return _Group_BeiZhu; }
            set { _Group_BeiZhu = value; }
        }

    }
    public class AMGroups : AMBase
    {
        public AMGroups()
        {
            //Init
        }

        private List<AMGroup> _AllGroups = null;
        public List<AMGroup> AllGroups 
        {
            get { return _AllGroups; }
            set { _AllGroups = value; }
        }
        public void Add(AMGroup amg)
        {
            _AllGroups.Add(amg);
        }
        public void Del(AMGroup amg)
        {
            _AllGroups.Remove(amg);
        }
    }

    public class AMGroupRules : AMBase
    {
        public AMGroupRules()
        {
            //Init
        }
        private List<string> _AllAMGroupRules = null;
        public void Add(string Rule)
        {
            _AllAMGroupRules.Add(Rule);
        }
        public void Del(string Rule)
        {
            _AllAMGroupRules.Remove(Rule);
        }
        public List<string> AllAMGroupRules
        {
            get { return _AllAMGroupRules; }
            set { _AllAMGroupRules = value; }
        }
    }
}
