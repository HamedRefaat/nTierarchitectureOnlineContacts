using OnlineContacts.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineContacts.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SetCulture(string culture)
        {
            // Validate input
            culture = culture == "ar" ? "ar-EG" : "en-US";

            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_oNLINEculture"];
            if (cookie != null)
                cookie.Value = culture;   // update cookie value
            else
            {

                cookie = new HttpCookie("_oNLINEculture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);

            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}