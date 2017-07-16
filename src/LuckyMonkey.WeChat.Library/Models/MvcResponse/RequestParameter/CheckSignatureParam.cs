namespace LuckyMonkey.WeChat.Library.Models
{
    public class CheckSignatureParam
    {
        /// <summary>
        /// 微信加密签名，signature结合了开发者填写的token参数和请求中的timestamp参数、nonce参数
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        /// 随机数
        /// </summary>
        public string Nonce { get; set; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string Echostr { get; set; }
    }
}
