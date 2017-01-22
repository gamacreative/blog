using Blog.MVC.Data;
using Blog.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Blog.MVC.Controllers
{
    public class eBookController : Controller
    {

        private readonly ApplicationDbContext _context;

        public eBookController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Lead model)
        {
            //TODO: validações
            model.IP = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            _context.Leads.Add(model);
            _context.SaveChanges();

            return View(model);
        }


        public IActionResult Download(int ID)
        {
            var lead = _context.Leads.Where(t => t.ID == ID).SingleOrDefault();
            lead.DownloadCount += 1;
            _context.Attach(lead);
            _context.SaveChanges();

            return View(lead);
        }

    }
}