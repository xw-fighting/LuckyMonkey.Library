using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace LuckyMonkey.Utility.Library.XmlRelated
{
    /// <summary>
    /// Xml工具类【将xml格式的数据序列化为对象，或将对象反序列化为xml】
    /// </summary>
    public class XmlUtility
    {
        /// <summary>
        /// 将接收到的xml字符串序列化为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static T XmlToObject<T>(string xml, Encoding encoding = null)
        {
            try
            {
                var mySerializer = new XmlSerializer(typeof(T));
                if (encoding == null)
                {
                    encoding = Encoding.UTF8;
                }
                var xmlBuffer = encoding.GetBytes(xml);
                using (var ms = new MemoryStream(xmlBuffer))
                {
                    using (var streamReader = new StreamReader(ms, encoding))
                    {
                        return (T)mySerializer.Deserialize(streamReader);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 将对象转为xml格式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ObjectToXml<T>(T obj, Encoding encoding = null)
        {
            try
            {
                if (obj == null)
                    throw new ArgumentNullException("obj");
                var mySerializer = new XmlSerializer(obj.GetType());
                using (var ms = new MemoryStream())
                {
                    mySerializer.Serialize(ms, obj);
                    ms.Position = 0;
                    StreamReader sr = new StreamReader(ms);
                    string str = sr.ReadToEnd();
                    return str;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// 读取xml内容中指定xpath中的元素值
        /// </summary>
        /// <param name="xPath">xml中元素值</param>
        /// <param name="inputXml">xml输入字符串</param>
        /// <returns></returns>
        public static string ReadXmlNodeValue(string xPath, string inputXml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(inputXml);
            var node = doc.SelectSingleNode(xPath);
            if (node == null)
                return string.Empty;
            XmlCDataSection section = node.FirstChild as XmlCDataSection;
            if (section == null)
                return string.Empty;
            return section.Value;
        }
    }
}
