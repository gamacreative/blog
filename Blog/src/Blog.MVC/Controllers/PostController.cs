using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.MVC.Data;

namespace Blog.MVC.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 0)
        {
            var posts = _context.Posts.OrderBy(t => t.createDate).Skip(10 * page).Take(10);

            return View(posts.ToList());
        }

        public IActionResult Details(int id)
        {
            var post = _context.Posts.Where(t => t.ID == id);
            return View(post.SingleOrDefault());
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
