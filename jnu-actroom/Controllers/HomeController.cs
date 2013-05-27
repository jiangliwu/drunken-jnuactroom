using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jnu_actroom.Models;
namespace jnu_actroom.Controllers
{
    public class HomeController : Controller
    {
    

        public ActionResult Index()
        {
            ViewBag.Message = "欢迎来到暨南大学课后讨论网.";
            //return View(db.Posters.OrderByDescending(i=>i.PostTime).ToList());
            return View(new CatalogDBContext().Catalogs.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
