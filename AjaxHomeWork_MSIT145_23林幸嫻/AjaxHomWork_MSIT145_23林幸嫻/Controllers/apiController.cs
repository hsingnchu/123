using AjaxHomWork_MSIT145_23林幸嫻.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text;

namespace AjaxHomWork_MSIT145_23林幸嫻.Controllers
{
    //--------------for 作業2--------------
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


        //--------------for 作業3--------------



        private readonly DemoContext _context;
        private readonly IWebHostEnvironment _host;

        public IActionResult City()
        {
            var cities = _context.Addresses.Select(a => a.City).Distinct();
            return Json(cities);
        }

        public apiController(DemoContext context, IWebHostEnvironment host) 
        {
            _context = context;
            _host = host;
        }


        public IActionResult Site(string city)
        {
            var sites = _context.Addresses.Where(s => s.City == city).Select(s => s.SiteId).Distinct();
            return Json(sites);
        }

        public IActionResult Road(string site)
        {
            var roads = _context.Addresses.Where(r => r.SiteId == site).Select(s => s.Road).Distinct();
            return Json(roads);
        }

        public IActionResult CheckAccount(string name)
        {
            var exists = _context.Members.Any(m => m.Name == name);

            return Content(exists.ToString(), "text/palin");
        }

        public IActionResult CheckEmail(string email)
        {
            var exists = _context.Members.Any(m => m.Email == email);

            return Content(exists.ToString(), "text/palin");
        }

        public IActionResult Register(Member member, IFormFile photo)
        {
            string fileName = photo.FileName;
            string filePath = Path.Combine(_host.WebRootPath, "uploads", fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                photo.CopyTo(fileStream);
            }


            member.FileName = fileName;
            byte[]? imgByte = null;
            using (var memoryStream = new MemoryStream())
            {
                photo.CopyTo(memoryStream);
                imgByte = memoryStream.ToArray();
            }
            member.FileData = imgByte;

            _context.Members.Add(member);
            _context.SaveChanges();


            return Content($"{filePath}");

        }
    }
}

