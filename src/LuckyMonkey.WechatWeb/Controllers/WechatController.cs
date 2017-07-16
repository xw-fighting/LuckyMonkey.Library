using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LuckyMonkey.WechatWeb.Controllers
{
    public class WechatController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}