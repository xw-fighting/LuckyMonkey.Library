using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyMonkey.WeChat.Library
{
    /// <summary>
    /// 文本消息处理器
    /// </summary>
    public class TextHandler : IHandler
    {
        public string InputXml { get; set; }
        public TextHandler(string inputXml)
        {
            InputXml = inputXml;
        }
        public string HandlerRequest()
        {
            throw new NotImplementedException();
        }
    }
}
