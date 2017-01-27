using Blog.MVC.Data;
using Blog.MVC.Models.CalculatorViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.MVC.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CalculatorController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var model = new CalculatorViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Result(CalculatorViewModel model)
        {

            try
            {
                if (model.Lead.Name.Split(' ').Count() < 2)
                {
                    throw new System.Exception("Preencher nome completo.");
                }

                var email = _context.Leads.Where(t => t.Email == model.Lead.Email).Count();
                if (email < 0)
                {
                    model.Lead.dataCriacao = DateTime.Now;
                    model.Lead.IP = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    _context.Leads.Add(model.Lead);
                    _context.SaveChanges();
                }

                model.TotalValue = Calculate(model);
            }
            catch (System.Exception ex)
            {
                ViewData["Error"] = ex.Message;
                return View("Index", model);
            }
            return View(model);

        }

        private double Calculate(CalculatorViewModel model)
        {
            var city = _context.Cities.Where(t => t.Name == model.Lead.City).SingleOrDefault();

            if (city == null || city.ID == 0)
            {
                city = new Models.CityCalculator()
                {
                    ID = 0,
                    Name = model.Lead.City,
                    Value = 900
                };
            }

            double totalValue = city.Value;

            totalValue += model.Internet == option.Yes ? 150 : 0;
            totalValue += model.Lunch == option.Yes ? 450 : 270;
            totalValue += model.Dinner == option.Yes ? 450 : 270;
            totalValue += model.Clean == option.Yes ? 100 : 300;

            totalValue *= model.Living == option.Yes ? 1 : 0.6;

            return totalValue;

        }
    }
}