using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace AuthSystem.AuthData
{
    /// <summary>
    /// XML配置文件类
    /// </summary>
    public class XmlConfig
    {
        #region 公共变量
        private string _filePath; //配置文件路径
        private XmlDocument _xmlDoc = new XmlDocument();//xml配置文件对象
        private XmlElement _xmlRoot;//根节点
        private XmlDeclaration _xmlDec;//文件头
        private bool HasChange = false;//是否有更改
        private List<XmlNode> _AllNodes = new List<XmlNode>();//所有节点
        #endregion

        #region 初始化
        public XmlConfig()
        {
            //Init
        }
        public XmlConfig(string FilePath)
        {
            _filePath = FilePath;
            if (HasFile(FilePath))
            {
                LoadFile(FilePath);
            }
            else
            {
                NewFile(FilePath);
            }
        }
        #endregion

        #region Other
        /// <summary>
        /// 检测是否存在配置文件
        /// </summary>
        /// <param name="FilePath">配置文件路径</param>
        /// <returns>Bool</returns>
        public bool HasFile(string FilePath)
        {
            try
            {
                return File.Exists(FilePath);
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        #endregion

        #region FileManager
        public void NewFile(string FilePath)
        {
            _filePath = FilePath;
            _xmlDec = _xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
            _xmlDoc.AppendChild(_xmlDec);
            _xmlRoot = _xmlDoc.CreateElement("XmlConfiguation");
            _xmlDoc.AppendChild(_xmlRoot);
            _xmlDoc.Save(FilePath);
        }
        public void Save()
        {
            try
            {
                _xmlDoc.Save(_filePath);
                HasChange = false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Save(string FilePath)
        {
            try
            {
                _xmlDoc.Save(FilePath);
                HasChange = false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void LoadFile(string FilePath)
        {
            try
            {
                _filePath = FilePath;
                FileStream fs = new FileStream(FilePath, FileMode.Open);
                _xmlDoc.Load(fs);
                _xmlRoot = (XmlElement)_xmlDoc.GetElementsByTagName("XmlConfiguation")[0];
                fs.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Node
        /// <summary>
        /// 添加1级节点
        /// </summary>
        /// <param name="nodeName">节点名称</param>
        public void AddNode(string nodeName)
        {
            if (_xmlRoot.GetElementsByTagName(nodeName).Count==0) //存在相同的节点，则不做处理
            {
                XmlElement tmpEle = _xmlDoc.CreateElement(nodeName);
                _xmlRoot.AppendChild(tmpEle);
            }
        }
        /// <summary>
        /// 根据节点名，添加子节点
        /// </summary>
        /// <param name="nodeName">要添加的节点名</param>
        /// <param name="upNode">上级节点名</param>
        public void AddNode(string nodeName, string upNode)
        {
            XmlNode tmpNode=GetNode(upNode);
            XmlElement tmpEle = _xmlDoc.CreateElement(nodeName);
            tmpNode.AppendChild(tmpEle);
        }
        public void DelNode(string nodeName)
        {
            XmlNode tmpNode = _xmlRoot.GetElementsByTagName(nodeName)[0];
            _xmlRoot.RemoveChild(tmpNode);
        }
        public void DelNode(string nodeName, string upNode)
        {
            XmlNode tmpUpNode = GetNode(upNode);
            XmlNode tmpNode = ((XmlElement)tmpUpNode).GetElementsByTagName(nodeName)[0];
            tmpUpNode.RemoveChild(tmpNode);
        }
        #endregion

        #region KeyValue
        /// <summary>
        /// 给指定Node添加Key,Value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="Node"></param>
        public void AddKeyValue(string key, string value, string Node)
        {
            XmlElement tmpEle = (XmlElement)GetNode(Node);
            tmpEle.SetAttribute(key, value);
        }
        public void DelKeyValue(string key, string Node)
        {
            XmlElement tmpEle = (XmlElement)GetNode(Node);
            tmpEle.RemoveAttribute(key);
        }
        #endregion

        #region Value
        /// <summary>
        /// 指定Node添加Value
        /// </summary>
        /// <param name="value"></param>
        /// <param name="nodeName"></param>
        public void AddValue(string value, string nodeName)
        {
            XmlElement tmpEle = (XmlElement)GetNode(nodeName);
            tmpEle.InnerText = value;
        }
        public void DelValue(string nodeName)
        {
            XmlElement tmpEle = (XmlElement)GetNode(nodeName);
            tmpEle.InnerText = "";
        }
        #endregion

        #region test
        public void test()
        {
            
        }
        #endregion

        #region 遍历节点
        /// <summary>
        /// 获取指定节点的子节点
        /// </summary>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public List<string> GetNodes(string nodeName)
        {
            List<string> tmpList = new List<string>();
            XmlNode tmpNode = GetNode(nodeName);
            foreach (XmlNode x in tmpNode.ChildNodes)
            {
                tmpList.Add(x.Name);
            }
            return tmpList;
        }
        public List<string> GetNodes()
        {
            List<string> tmpList = new List<string>();
            foreach (XmlNode x in _xmlRoot.ChildNodes)
            {
                tmpList.Add(x.Name);
            }
            return tmpList;
        }

        private void GetAllNodes(XmlNode xmlNode)
        {
            foreach (XmlNode x in xmlNode.ChildNodes)
            {
                _AllNodes.Add(x);
                if (x.ChildNodes.Count == 0)
                {
                    continue;
                }
                else
                {
                    GetAllNodes(x);
                }
            }
        }
        /// <summary>
        /// 取指定名称的XmlNode
        /// </summary>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public XmlNode GetNode(string nodeName)
        {
            GetAllNodes(_xmlRoot);
            foreach (XmlNode x in _AllNodes)
            {
                if (x.Name == nodeName)
                {
                    return x;
                }
            }
            return _xmlDoc.CreateNode(XmlNodeType.Element, "Error", "");
        }
        #endregion

        #region 导入导出
        public MemoryStream Export()
        {
            MemoryStream tmpms = new MemoryStream();
            _xmlDoc.Save(tmpms);
            tmpms.Position = 0;
            return tmpms;
        }
        public void Import(MemoryStream ms)
        {

        }
        #endregion
    }

    /// <summary>
    /// XML配置文件类接口
    /// </summary>
    public interface IXmlConfig
    {
        bool HasFile(string FilePath);
        void NewFile(string FilePath);
        void Save();
        void SaveAs(string FilePath);
        void LoadFile(string FilePath);
        void AddNode(string nodeName, string upNode);
        void AddNode(string nodeName, string value, string upNode);
        void AddNode(string nodeName);
        void AddKeyValue(string key,string value,string upNode);
        string Export();
    }
}
