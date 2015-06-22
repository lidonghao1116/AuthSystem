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

        private string _Rule_BeiZhu = "";
        public string Rule_BeiZhu
        {
            get { return _Rule_BeiZhu; }
            set { _Rule_BeiZhu = value; }
        }
    }

    public class AMRules : AMBase
    {
        public AMRules() { }

        private List<AMRule> _AllAMRules = null;
        public List<AMRule> AllAMRules
        {
            get { return _AllAMRules; }
            set { _AllAMRules = value; }
        }
        public void Add(AMRule amr)
        {
            _AllAMRules.Add(amr);
        }
        public void Del(AMRule amr)
        {
            _AllAMRules.Remove(amr);
        }
    }

    public class AMRulesID_ForList : AMBase
    {
        public AMRulesID_ForList()
        {
            //Init
        }
        private List<string> _AllRulesID = null;
        public void Add(string Rule)
        {
            _AllRulesID.Add(Rule);
        }
        public void Del(string Rule)
        {
            _AllRulesID.Remove(Rule);
        }
        public List<string> AllRulesID
        {
            get { return _AllRulesID; }
            set { _AllRulesID = value; }
        }
    }
}
