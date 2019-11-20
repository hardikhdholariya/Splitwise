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
    public class notificationsController : Controller
    {
        private notificationDBContext db = new notificationDBContext();
        private frdlistDBContext fdb = new frdlistDBContext();
        // GET: notifications
        /*public ActionResult AddExpense()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExpense(string desc,decimal amount)
        {
            string mymail = (string)Session["mymail"];
            string fmail = (string)Session["fmail"];
            notification n = new notification();
            notification nr = new notification();
            n.loginuser = mymail;
            n.friendemail = fmail;
            n.description = desc;
            n.amount = amount;
            nr.amount = amount;
            nr.description = desc;
            nr.loginuser = fmail;
            nr.friendemail = mymail;
            //frdlist f = fdb.frdlists.FirstOrDefault(x => x.loginuser == mymail && x.Email == fmail);
            //frdlist fr = fdb.frdlists.FirstOrDefault(x => x.loginuser == fmail && x.Email == mymail);
            //f.rupee += amount;
            //fr.rupee -= amount;
            db.notifications.Add(n);
            db.notifications.Add(nr);
            db.SaveChanges();
            //fdb.SaveChanges();
            return RedirectToAction("Index", "frdlists");
        }*/
        public ActionResult Index(string email)
        {
            Session.Add("fmail", email);
            return RedirectToAction("AddExpense");
        }

        // GET: notifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notification notification = db.notifications.Find(id);
            if (notification == null)
            {
                return HttpNotFound();
            }
            return View(notification);
        }

        // GET: notifications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: notifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,loginuser,friendemail,description,amount")] notification notification)
        {
            if (ModelState.IsValid)
            {
                db.notifications.Add(notification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(notification);
        }

        // GET: notifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notification notification = db.notifications.Find(id);
            if (notification == null)
            {
                return HttpNotFound();
            }
            return View(notification);
        }

        // POST: notifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,loginuser,friendemail,description,amount")] notification notification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notification);
        }

        // GET: notifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notification notification = db.notifications.Find(id);
            if (notification == null)
            {
                return HttpNotFound();
            }
            return View(notification);
        }

        // POST: notifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            notification notification = db.notifications.Find(id);
            db.notifications.Remove(notification);
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
