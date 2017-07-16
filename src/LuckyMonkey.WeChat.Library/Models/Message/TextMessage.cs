
using System;

namespace LuckyMonkey.WeChat.Library
{
    public class TextMessage// : Message
    {
        public TextMessage()
        {
            MsgType = "text";
        }

        /// <summary>
        /// 发送方帐号
        /// </summary>
        public string FromUserName { get; set; }
        /// <summary>
        /// 接收方账号
        /// </summary>
        public string ToUserName { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public string MsgType { get; protected set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 消息ID
        /// </summary>
        public string MsgId { get; set; }



        private static string m_Template;
        /// <summary>
        /// 模板
        /// </summary>
        public virtual string Template
        {
            get
            {
                if (string.IsNullOrEmpty(m_Template))
                {
                    LoadTemplate();
                }

                return m_Template;
            }
        }
        public static void LoadTemplate()
        {
            m_Template = @"<xml>
                                <ToUserName><![CDATA[{0}]]></ToUserName>
                                <FromUserName><![CDATA[{1}]]></FromUserName>
                                <CreateTime>{2}</CreateTime>
                                <MsgType><![CDATA[{3}]]></MsgType>
                                <Content><![CDATA[{4}]]></Content>
                                <MsgId>{5}</MsgId>
                            </xml>";
        }
        /// <summary>
        /// 生成内容
        /// </summary>
        /// <returns></returns>
        public virtual string GenerateContent()
        {
            return string.Format(this.Template, this.ToUserName, this.FromUserName, this.CreateTime, this.MsgType, this.Content, this.MsgId);
        }
        
    }
}
