using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LuckyMonkey.Utility.Library
{
    /// <summary>
    /// Http请求相关的工具类
    /// </summary>
    public class HttpRequestUtility
    {
        /// <summary>
        /// 读取请求报文中的内容，将其转换为字符串
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static async Task<string> ReadRequestContentAsync(HttpRequest request)
        {
            var requestStr = string.Empty;
            //获取报文流
            using(var stream = request.Body)
            {
                //读取流
                using(var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    //
                    requestStr =await  reader.ReadToEndAsync();
                }
            }
            return requestStr;
        }

        /// <summary>
        /// 读取请求报文中的内容，将其转换为字符串
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static  string ReadRequestContent(HttpRequest request)
        {
            var requestStr = string.Empty;
            //获取报文流
            using (var stream = request.Body)
            {
                //读取流
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    //
                    requestStr = reader.ReadToEnd();
                }
            }
            return requestStr;
        }
    }
}
