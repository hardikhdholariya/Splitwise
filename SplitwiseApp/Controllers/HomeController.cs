using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SplitwiseApp.Models;
namespace SplitwiseApp.Controllers
{
    public class HomeController : Controller
    {
        private notificationDBContext ndb = new notificationDBContext(); 
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Activity(string searchString)
        {
            string mymail = (string)Session["mymail"];
            var li = ndb.notifications.Where(x => x.loginuser == mymail).ToList();
            ViewBag.abc = li;
           
            return View();

        }
    }
}