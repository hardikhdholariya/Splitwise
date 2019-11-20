using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SplitwiseApp.Models;

namespace SplitwiseApp.Controllers
{
    public class frdlistsController : Controller
    {
        private frdlistDBContext db = new frdlistDBContext();
        private notificationDBContext ndb = new notificationDBContext();
        // GET: frdlists
        public ActionResult AddExpense()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExpense(string desc, decimal amount)
        {
            string mymail = (string)Session["mymail"];
            string fmail = (string)Session["fmail"];
            notification n = new notification();
            notification nr = new notification();
            n.loginuser = mymail;
            n.friendemail = fmail;
            n.description = desc;
            n.amount = amount;
            nr.amount = -amount;
            nr.description = desc;
            nr.loginuser = fmail;
            nr.friendemail = mymail;
            frdlist f = db.frdlists.FirstOrDefault(x => x.loginuser == mymail && x.Email == fmail);
            frdlist fr = db.frdlists.FirstOrDefault(x => x.loginuser == fmail && x.Email == mymail);
            if (f != null)
            {
                decimal c = f.rupee;
                c+=amount;
                f.rupee = c;
            }
            if (fr != null)
            {
                decimal c = fr.rupee;
                c -= amount;
                fr.rupee = c;
            }
            ndb.notifications.Add(n);
            ndb.notifications.Add(nr);
            db.SaveChanges();
            ndb.SaveChanges();
            return RedirectToAction("Index", "frdlists");
        }
        public ActionResult Add(string email)
        {
            Session.Add("fmail", email);
            return RedirectToAction("AddExpense");
        }
        public ActionResult History(string email)
        {
            string mymail = (string)Session["mymail"];

            var n = ndb.notifications.Where(x => x.loginuser == mymail && x.friendemail == email).ToList();
            ViewBag.list = n;
            return View();
        }
      
        public ActionResult Index()
        {
            string abc = (string)Session["mymail"];
            var li = db.frdlists.Where(x => x.loginuser == abc).ToList();
            decimal total=0; 
            ViewBag.frds = li;
            foreach(var item in li)
            {
                total += item.rupee;
            }
            ViewBag.total = total;
            return View();
        }

        // GET: frdlists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            frdlist frdlist = db.frdlists.Find(id);
            if (frdlist == null)
            {
                return HttpNotFound();
            }
            return View(frdlist);
        }

        // GET: frdlists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: frdlists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,loginuser,friendname,Email,rupee")] frdlist frdlist)
        {
            if (ModelState.IsValid)
            {
                db.frdlists.Add(frdlist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(frdlist);
        }

        // GET: frdlists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            frdlist frdlist = db.frdlists.Find(id);
            if (frdlist == null)
            {
                return HttpNotFound();
            }
            return View(frdlist);
        }

        // POST: frdlists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,loginuser,friendname,Email,rupee")] frdlist frdlist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(frdlist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(frdlist);
        }

        // GET: frdlists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            frdlist frdlist = db.frdlists.Find(id);
            if (frdlist == null)
            {
                return HttpNotFound();
            }
            return View(frdlist);
        }

        // POST: frdlists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            frdlist frdlist = db.frdlists.Find(id);
            db.frdlists.Remove(frdlist);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
