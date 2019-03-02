using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml;
using Util.Helpers;

namespace Util {
    /// <summary>
    /// 系统扩展 - 字符串
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 移除末尾字符串
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="removeValue">要移除的值</param>
        public static string RemoveEnd( this string value,string removeValue ) {
            return String.RemoveEnd( value,removeValue );
        }


        public static IReadOnlyDictionary<string, string> ToDictionay(this string xmlContent)
        {
            IDictionary<string, string> dic = new Dictionary<string, string>();
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlContent);
            var node = xml.SelectSingleNode("/xml");
            if (node.HasChildNodes)
            {
                for (int i = 0; i < node.ChildNodes.Count; i++)
                {
                    dic.Add(node.ChildNodes[i].Name, node.ChildNodes[i].InnerText);
                }
            }
            IReadOnlyDictionary<string,string> readonlyDic = new ReadOnlyDictionary<string, string>(dic);
            return readonlyDic;

        }
    }
}
