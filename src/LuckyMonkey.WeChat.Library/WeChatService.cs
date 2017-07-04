using LuckyMonkey.Utility.Library.EncryptionRelated;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyMonkey.WeChat.Library
{
    public class WeChatService
    {
        private HttpRequest Request { get; set; }
        public WeChatService(HttpRequest request)
        {
            Request = request;
        }

        public void MvcResponse()
        {

        }

        public string HandlerResponse()
        {
            var method = Request.Method.ToUpper();
            if (string.IsNullOrEmpty(method))
                return string.Empty ;
            if (method.Equals("GET"))
            {
                if (VerifyGateway())
                    return Request.Query["echostr"];
            }
            else if (method.Equals("POST"))
            {
                return ResopnseMsg();
            }
            return string.Empty;
        }

        private string ResopnseMsg()
        {
            var msgType = Request.Query["MsgType"];

            //switch (msgType)
            //{
            //    case "event":
            //        HandlerFactory
            //    default:
            //        break;
            //}
            return msgType;
        }

        private bool VerifyGateway()
        {
            var singnature = Request.Query["singnature"];
            var timestamp = Request.Query["Timestamp"];
            var nonce = Request.Query["Nonce"];
            var token = "xiaowei";
            //加入集合，进行字典排序
            var list = new List<string>()
            {
                token,
                timestamp,
                nonce
            };
            list.Sort();
            //拼串
            var input = string.Empty;
            list.ForEach(l =>
            {
                input += l;
            });
            //对input进行SHA1加密
            var newSingnature = EncryptionAlgorithm.Sha1Encrypt(input);
            return newSingnature.Equals(singnature);
        }
    }
}
