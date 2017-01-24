using Blog.MVC.Data;
using Blog.MVC.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.MVC.Controllers
{
    public class ContentController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ContentController(ApplicationDbContext context)
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
            try
            {
                if (model.Name.Split(' ').Count() < 2)
                {
                    throw new System.Exception("Preencher nome completo.");
                }

                var email = _context.Leads.Where(t => t.Email == model.Email).Count();
                if (email > 0)
                    return View("Download");


                //SendEmail(model.Email, "eBook", "Teste eBook");
                //TODO: validações
                model.IP = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                _context.Leads.Add(model);
                _context.SaveChanges();
            }
            catch (System.Exception ex)
            {
                ViewData["Error"] = ex.Message;
                return View("Index");
            }
            return View("Download");
        }


        public void SendEmail(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Joe Bloggs", "jbloggs@example.com"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain") { Text = message };

            using (var client = new SmtpClient())
            {
                client.LocalDomain = "some.domain.com";
                client.ConnectAsync("smtp.relay.uri", 25, SecureSocketOptions.None).ConfigureAwait(false);
                client.SendAsync(emailMessage).ConfigureAwait(false);
                client.DisconnectAsync(true).ConfigureAwait(false);
            }
        }

        [HttpPost]
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