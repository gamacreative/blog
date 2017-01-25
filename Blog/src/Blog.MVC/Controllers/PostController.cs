using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.MVC.Data;
using Blog.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult View(string id)
        {
            var post = _context.Posts.FromSql("select * from posts where title = {0} COLLATE LATIN1_GENERAL_CI_AI", id.Replace('-', ' ')); ;
            return View("Details", post.SingleOrDefault());
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Subtitle,Text")] Post Post)
        {
            if (id != Post.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(Post.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(Post);
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.ID == id);
        }
    }
}
