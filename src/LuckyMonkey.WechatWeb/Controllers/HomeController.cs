using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LuckyMonkey.WeChat.Library;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace LuckyMonkey.WechatWeb.Controllers
{
    public class HomeController : Controller
    {
        private IHttpContextAccessor Accessor;
        public HomeController(IHttpContextAccessor _accessor)
        {
            Accessor = _accessor;
        }
        [HttpGet]
        public  string Index()
        {
            var request = HttpContext.Request;
            var wechatService = new WeChatService(request);
            var response = wechatService.HandlerResponse();
            return response;
        }

        [HttpPost]
        public async Task Index(string name)
        {
            //var request = HttpContext.Request;
            var context = Accessor.HttpContext;
            var request = context.Request;
            var wechatService = new WeChatService(request);
            var response =  wechatService.HandlerResponse();
            context.Response.Clear();
              
            await context.Response.WriteAsync(response, Encoding.UTF8);
            
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
