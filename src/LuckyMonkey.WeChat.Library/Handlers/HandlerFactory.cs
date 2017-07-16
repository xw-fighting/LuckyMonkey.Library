using LuckyMonkey.Utility.Library;

namespace LuckyMonkey.WeChat.Library
{
    /// <summary>
    /// 处理器转发工厂：通过传递过来的参数，创建相应的处理器进行处理
    /// </summary>
    public class HandlerFactory
    {
        /// <summary>
        /// 微信各类事件创建器
        /// </summary>
        /// <param name="inputXml"></param>
        /// <returns></returns>
        public static IHandler CreateHandler(string inputXml)
        {
            IHandler handler = null;
            var msgType = XmlUtility.ReadXmlNodeValue("/xml/MsgType", inputXml);
            if (string.IsNullOrEmpty(msgType))
                return null;
            switch (msgType)
            {
                case "event":
                    handler = new EventsHandler(inputXml);
                    break;
                case "text":
                    handler = new TextHandler(inputXml);
                    break;
                default:
                    break;
            }
            return handler;

        }
    }
}
