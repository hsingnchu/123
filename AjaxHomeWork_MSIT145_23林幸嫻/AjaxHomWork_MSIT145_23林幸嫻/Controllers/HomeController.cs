using AjaxHomWork_MSIT145_23林幸嫻.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Xml.Linq;

namespace AjaxHomWork_MSIT145_23林幸嫻.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DemoContext _context;


        public HomeController(ILogger<HomeController> logger , DemoContext conetxt)
        {
            _logger = logger;
            _context = conetxt;
        }

        public IActionResult 測試Demo()
        {
            var name = _context.Members;
            return View(name);
        }


        public IActionResult 作業1()
        {
            return View();
        }

        public IActionResult 作業2()
        {
            return View();
        }


        public IActionResult 作業3()
        {

            return View();

        }

        public IActionResult 作業4()
        {

            return View();

        }



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}