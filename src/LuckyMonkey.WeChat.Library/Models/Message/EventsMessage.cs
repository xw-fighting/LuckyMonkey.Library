using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LuckyMonkey.WeChat.Library
{
    [XmlRoot("xml")]
    public class EventsMessage //: Message
    {
        //public EventsMessage()
        //{
        //    MsgType = "event";
        //}
        /// <summary>
        /// 发送方帐号
        /// </summary>
        [XmlElement("FromUserName")]
        public string FromUserName { get; set; }
        /// <summary>
        /// 接收方账号
        /// </summary>
        [XmlElement("ToUserName")]
        public string ToUserName { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        [XmlElement("MsgType")]
        public string MsgType { get;  set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [XmlElement("CreateTime")]
        public string CreateTime { get; set; }
        /// <summary>
        /// 事件类型
        /// </summary>
        [XmlElement("Event")]
        public string Event { get; set; }
        /// <summary>
        /// 事件KEY值，与自定义菜单接口中KEY值对应
        /// </summary>
        [XmlElement("EventKey")]
        public string EventKey { get; set; }
        
    }
}
