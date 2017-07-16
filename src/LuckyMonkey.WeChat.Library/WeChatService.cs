using LuckyMonkey.Utility.Library;
using LuckyMonkey.WeChat.Library.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyMonkey.WeChat.Library
{
    public class WeChatService
    {
        private HttpRequest Request { get; set; }
        public WeChatService(HttpRequest request)
        {
            Request = request;
        }

        public void MvcGet(CheckSignatureParam param)
        {

        }

        public void MvcPost()
        {

        }

        public string HandlerResponse()
        {
            var method = Request.Method.ToUpper();
            if (string.IsNullOrEmpty(method))
                return string.Empty;
            if (method.Equals("GET"))
            {
                if (VerifyGateway())
                    return Request.Query["echostr"];
            }
            else if (method.Equals("POST"))
            {
                return  ResopnseMsg();
            }
            return string.Empty;
        }

        private  string ResopnseMsg()
        {
            //读取出报文中的xml格式数据
            var requestXml = HttpRequestUtility.ReadRequestContent(Request);
            //创建一个处理器对请求进行处理
            var handler = HandlerFactory.CreateHandler(requestXml);
            if (handler == null)
                return string.Empty;
            //通过请求的xml获取到相应的处理器进行处理请求
            return handler.HandlerRequest();
        }

        private bool VerifyGateway()
        {
            var singnature = Request.Query["signature"].FirstOrDefault();
            var timestamp = Request.Query["timestamp"];
            var nonce = Request.Query["nonce"];
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
            var newSingnature = EncryptionUtility.Sha1Encrypt(input);
            return newSingnature.Equals(singnature);
        }
    }
}
