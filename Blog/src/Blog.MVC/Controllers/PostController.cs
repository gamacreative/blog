using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.MVC.Data;
using Blog.MVC.Models;
using Microsoft.AspNetCore.Authorization;

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

        [Authorize]
        public IActionResult List()
        {
            var model = _context.Posts.ToList();
            return View(model);
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create(Post model)
        {
            model.createDate = DateTime.Now;
            _context.Posts.Add(model);
            _context.SaveChanges();
            return View();
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var post = _context.Posts.Where(t => t.ID == id).SingleOrDefault();
            return View(post);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Edit(int id, [Bind("ID,Text,Title,Subtitle")]Post model)
        {

            _context.Update(model);
            _context.SaveChanges();
            return View();
        }
    }
}
