using LuckyMonkey.Utility.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyMonkey.WeChat.Library
{
    /// <summary>
    /// 事件处理器
    /// </summary>
    public class EventsHandler : IHandler
    {
        public string InputXml { get; set; }
        public EventsHandler(string inputXml)
        {
            InputXml = inputXml;
        }
        /// <summary>
        /// 对接收到的数据进行分析
        /// </summary>
        /// <returns></returns>
        public string HandlerRequest()
        {
            //1.0回复消息
            var response = string.Empty;
            var eventObj = XmlUtility.XmlToObject<EventsMessage>(InputXml);
            if (eventObj.Event.Equals("subscribe", StringComparison.OrdinalIgnoreCase))
            {
                var textMessage = new TextMessage
                {
                    FromUserName = eventObj.ToUserName,
                    ToUserName = eventObj.FromUserName,
                    CreateTime = GetNowTime(),
                    Content = "欢迎您关注***，我是大哥大，有事就问我，呵呵！\n\n",

                };
                response = textMessage.GenerateContent();
            }
            return response;

            //2.0 将需要的数据保存到数据库
        }

        public static string GetNowTime()
        {
            DateTime timeStamp = new DateTime(1970, 1, 1);  //得到1970年的时间戳
            long a = (DateTime.UtcNow.Ticks - timeStamp.Ticks) / 10000000;
            return a.ToString();
        }
    }
}
