using AjaxHomWork_MSIT145_23林幸嫻.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;

namespace AjaxHomWork_MSIT145_23林幸嫻.Controllers
{

    public class apiController : Controller
    {
        public IActionResult Index(string name)
        {
            //DemoContext context = new DemoContext();
            //var names = context.Members;
            //string namess = string.Join(" ", names);
            string namess = "Jack Mary Nancy Tom Eric";
            if (string.IsNullOrEmpty(name))
            {
                return Content($"未輸入名稱", "text/plain", Encoding.UTF8);
            }

            else if (namess.Contains(name))
            {
                return Content($"名稱已存在，請改用其他名稱", "text/plain", Encoding.UTF8);
            }

            return Content($"{name}可申請!", "text/plain", Encoding.UTF8);
        }

    }
}

