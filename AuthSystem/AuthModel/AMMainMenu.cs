using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuthSystem.AuthModel
{
    #region 1-------单个菜单文本数据对象
    /// <summary>
    /// 单个菜单文本数据对象
    /// </summary>
    public class AMMainMenu :AMBase
    {
        public AMMainMenu()
        {
            //
        }

        private string _MenuID;
        /// <summary>
        /// 菜单ID
        /// </summary>
        public string MenuID
        {
            get { return _MenuID; }
            set { _MenuID = value; }
        }

        private string _MenuName;
        /// <summary>
        /// 菜单名字
        /// </summary>
        public string MenuName
        {
            get { return _MenuName; }
            set { _MenuName = value; }
        }

        private string _MenuText;
        /// <summary>
        /// 菜单显示的文字
        /// </summary>
        public string MenuText
        {
            get { return _MenuText; }
            set { _MenuText = value; }
        }

        private string _MenuType;
        /// <summary>
        /// 菜单对象的类型
        /// </summary>
        public string MenuType
        {
            get { return _MenuType; }
            set { _MenuType = value; }
        }

        private string _MenuUpID;
        /// <summary>
        /// 上级菜单
        /// </summary>
        public string MenuUpID
        {
            get { return _MenuUpID; }
            set { _MenuUpID = value; }
        }
    }
    #endregion

    #region 2-------所有的菜单文本数据对象List
    public class AMMainMenus : AMBase
    {
        public AMMainMenus()
        {
            //
        }
        private List<AMMainMenu> _AMMainMenuValue;
        public List<AMMainMenu> AMMainMenuValue
        {
            get { return _AMMainMenuValue; }
            set { _AMMainMenuValue = value; }
        }
    }
    #endregion
}
