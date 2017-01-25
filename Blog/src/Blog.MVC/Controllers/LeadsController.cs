using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.MVC.Data;
using Microsoft.AspNetCore.Authorization;

namespace Blog.MVC.Controllers
{
    [Authorize]
    public class LeadsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public LeadsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 0)
        {
            var leads = _context.Leads.Count();
            return View(leads);
        }
    }
}