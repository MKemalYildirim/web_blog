using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Myblog.Models;

namespace Myblog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
          
            return View();
        }


        [HttpPost]
        public ActionResult Index(modaller model)
        {
            bool sonuc = false;

            WebMail.SmtpServer = ConfigurationManager.AppSettings["emailHost"];
            WebMail.SmtpPort = int.Parse(ConfigurationManager.AppSettings["emailPort"]);
            WebMail.UserName = ConfigurationManager.AppSettings["emailAccount"];
            WebMail.Password = ConfigurationManager.AppSettings["emailPassword"];
            WebMail.EnableSsl = true;

            // ek dosya alabilmek için
            //string file = Server.MapPath("~/img/map-image.png");

            try
            {
                WebMail.Send(
                    to: "digizevahir@gmail.com", subject: "Bize Ulaşan "+model.name_surname,
                    body: "Mesajı  " + model.massage+ "//==> Telefon Numarası :" + model.number,
                    replyTo: model.email, isBodyHtml: true
                   // ,filesToAttach: new[] { file }
                    );

                sonuc = true;
            }
            catch (Exception ex)
            {
                ViewBag.Hata = ex.Message;
            }

            ViewBag.Sonuc = sonuc;
            if (sonuc == true)
            {
                TempData["Basarili"] = "Teşekürler en kısa zamanda tafarınıza dönüş yapılacaktır.";

                return RedirectToAction("Index");
            }

            return View();
        }


    }
}