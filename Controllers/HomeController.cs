using FavGames.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;

namespace FavGames.Controllers
{
    public class HomeController : Controller
    {
        private GamesContext data { get; set; }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Contact(ContactFormModel contactForm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var smtpClient = new SmtpClient())
                    {
                        var mailMessage = new MailMessage
                        {
                            From = new MailAddress("your-email@example.com"),
                            Subject = "New Contact Form Submission",
                            Body = $"Name: {contactForm.Name}\nEmail: {contactForm.Email}\nMessage: {contactForm.Message}",
                            IsBodyHtml = false, // Set to true if you use HTML in your message
                        };
                        mailMessage.To.Add("recipient-email@example.com");

                        smtpClient.Host = "your-smtp-server"; // Set your SMTP server here
                        smtpClient.Port = 587; // Set your SMTP port here (587 is common for TLS)
                        smtpClient.EnableSsl = true;
                        smtpClient.Credentials = new NetworkCredential("smtp-username", "smtp-password"); // Set your SMTP credentials here

                        smtpClient.Send(mailMessage);
                    }

                    TempData["Message"] = "Your message has been sent successfully!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error sending email from contact form.");
                    // Handle the exception, log the error, and inform the user.
                    ModelState.AddModelError("", "There was an error sending your message. Please try again later.");
                }
            }

            // If we got this far, something failed; redisplay the form
            return View(contactForm);
        }

        public IActionResult Index()
        {
            return View(new ContactFormModel());
        }

        public IActionResult GameView()
        {
            return View();
        }

        public IActionResult About_Us()
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