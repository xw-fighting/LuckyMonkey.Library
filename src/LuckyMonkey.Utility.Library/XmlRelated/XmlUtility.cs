using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
        public static  T XmlToObject<T>(string xml, Encoding encoding = null)
        {
            try
            {
                var mySerializer = new XmlSerializer(typeof(T));
                if(encoding == null)
                {
                    encoding = Encoding.UTF8;
                }
                var xmlBuffer = encoding.GetBytes(xml);
                using (var ms = new MemoryStream(xmlBuffer))
                {
                    using(var streamReader = new StreamReader(ms, encoding))
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
        public static string ObjectToXml<T> (T obj,Encoding encoding = null )
        {
            try
            {
                if (obj == null)
                    throw new  ArgumentNullException("obj");
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
    }
}
