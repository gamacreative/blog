using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.MVC.Data;

namespace Blog.MVC.Controllers
{
    public class HomeController : Controller
    {
        //private ApplicationDbContext _context;
        public IActionResult Index()
        {
            //   var posts = _context.Posts.OrderBy(t => t.createDate).Take(10);

            return View();
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
