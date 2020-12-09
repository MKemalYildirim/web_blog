using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Net.Mail;
using System.Web.Mvc;
using Myblog.Models;
using System.Text;
using System.Net;


namespace Myblog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
          
            return View();
        }


        //[HttpPost]
        // public ActionResult Index(modaller model)
        // {
        //     bool sonuc = false;
        //    
        //     WebMail.SmtpServer = ConfigurationManager.AppSettings["emailHost"];
        //     WebMail.SmtpPort = int.Parse(ConfigurationManager.AppSettings["emailPort"]);
        //     WebMail.UserName = ConfigurationManager.AppSettings["emailAccount"];
        //     WebMail.Password = ConfigurationManager.AppSettings["emailPassword"];
        //     WebMail.EnableSsl = true;
        //
        //     // ek dosya alabilmek için
        //     //string file = Server.MapPath("~/img/map-image.png");
        //
        //     try
        //     {
        //         WebMail.Send(
        //             to: "digizevahir@gmail.com", subject: "Bize Ulaşan "+model.name_surname,
        //             body: "Mesajı  " + model.massage+ "//==> Telefon Numarası :" + model.number,
        //             replyTo: model.email, isBodyHtml: true
        //            // ,filesToAttach: new[] { file }
        //             );
        //
        //         sonuc = true;
        //     }
        //     catch (Exception ex)
        //     {
        //         ViewBag.Hata = ex.Message;
        //     }
        //
        //     ViewBag.Sonuc = sonuc;
        //     if (sonuc == true)
        //     {
        //         TempData["Basarili"] = "Teşekürler en kısa zamanda tafarınıza dönüş yapılacaktır.";
        //
        //         return RedirectToAction("Index");
        //     }
        //
        //     return View();
        // }
        [HttpPost]
        public ActionResult Index(modaller model)
        {
            MailMessage _mm = new MailMessage();



            _mm.SubjectEncoding = Encoding.Default;
            _mm.Subject = model.name_surname;
            _mm.BodyEncoding = Encoding.Default;
            _mm.Body ="Mesajınız:" +model.massage+"// Telefon Numarası:"+model.number+"//email:"+model.email;

            _mm.From = new MailAddress(ConfigurationManager.AppSettings["emailAccount"]);
            _mm.To.Add("digizevahir@gmail.com");


            SmtpClient _smtpClient = new SmtpClient();
            _smtpClient.Host = ConfigurationManager.AppSettings["emailHost"];
            _smtpClient.Port = int.Parse(ConfigurationManager.AppSettings["emailPort"]);
            _smtpClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["emailAccount"], ConfigurationManager.AppSettings["emailPassword"]);
            _smtpClient.EnableSsl = bool.Parse(ConfigurationManager.AppSettings["emailSLLEnable"]);

            _smtpClient.Send(_mm);

            TempData["Basarili"] = "Teşekürler en kısa zamanda tafarınıza dönüş yapılacaktır.";

            return RedirectToAction("Index");
        }


    }
}