using LuckyMonkey.Utility.Library;
using LuckyMonkey.WeChat.Library.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyMonkey.WeChat.Library
{
    /// <summary>
    /// 使用Mvc的模型绑定进行接收微信服务端的数据
    /// </summary>
    public class WechatServiceMvc
    {
        public string MvcGet(CheckSignatureParam param)
        {
            var token = "xiaowei";
            //加入集合，进行字典排序
            var list = new List<string>()
            {
                token,
                param.Timestamp,
                param.Nonce
            };
            list.Sort();
            //拼串
            var input = string.Empty;
            list.ForEach(l =>
            {
                input += l;
            });
            //对input进行SHA1加密
            var newSingnature = EncryptionUtility.Sha1Encrypt(input);
            if (newSingnature.Equals(param.Signature))
                return param.Echostr;
            return "验证失败";
        }

        public string MvcPost(HttpRequest request)
        {
            //读取出报文中的xml格式数据
            var requestXml = HttpRequestUtility.ReadRequestContent(request);
            //创建一个处理器对请求进行处理
            var handler = HandlerFactory.CreateHandler(requestXml);
            if (handler == null)
                return string.Empty;
            //通过请求的xml获取到相应的处理器进行处理请求
            return handler.HandlerRequest();
        }
    }
}
