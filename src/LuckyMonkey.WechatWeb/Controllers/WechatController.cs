using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LuckyMonkey.WeChat.Library.Models;
using LuckyMonkey.WeChat.Library;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace LuckyMonkey.WechatWeb.Controllers
{
    public class WechatController : Controller
    {
        private IHttpContextAccessor Accessor;
        public WechatController(IHttpContextAccessor _accessor)
        {
            Accessor = _accessor;
        }
        [HttpGet]
        public string Index(CheckSignatureParam param)
        {
            var wechatService = new WechatServiceMvc();
            var response = wechatService.MvcGet(param);
            return response;
        }

        [HttpPost]
        public async Task  Index()
        {
            var context = Accessor.HttpContext;
            var request = context.Request;
            var wechatService = new WechatServiceMvc();
            var response = wechatService.MvcPost(request);
            context.Response.Clear();

            await context.Response.WriteAsync(response, Encoding.UTF8);
        }
    }
}