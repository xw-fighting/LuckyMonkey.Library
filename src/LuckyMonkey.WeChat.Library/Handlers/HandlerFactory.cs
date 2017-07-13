using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace LuckyMonkey.WeChat.Library.Handlers
{
    /// <summary>
    /// 处理器转发工厂：通过传递过来的参数，创建相应的处理器进行处理
    /// </summary>
    public class HandlerFactory
    {
        
        public static IHandler CreateHandler(string inputXml)
        {
            IHandler handler = null;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(inputXml);
            //xml的根标签
            XmlNode node = doc.DocumentElement;
            //XmlNodeList list = doc.GetElementsByTagName("name");
            XmlNodeList list = doc.SelectNodes("books/book/name");
        }
    }
}
