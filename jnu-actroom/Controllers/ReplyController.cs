using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jnu_actroom.Models;

namespace jnu_actroom.Controllers
{
    [Authorize]
    public class ReplyController : Controller
    {
        private ReplyDBContext db = new ReplyDBContext();

        //
        // GET: /Reply/

        public ActionResult Index()
        {
            return View(db.Replys.ToList());
        }

        //
        // GET: /Reply/Details/5

        public ActionResult Details(int id = 0)
        {
            ReplyModel replymodel = db.Replys.Find(id);
            if (replymodel == null)
            {
                return HttpNotFound();
            }
            return View(replymodel);
        }

        //
        // GET: /Reply/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Reply/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReplyModel replymodel)
        {
            if (ModelState.IsValid)
            {
                db.Replys.Add(replymodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(replymodel);
        }

        //
        // GET: /Reply/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ReplyModel replymodel = db.Replys.Find(id);
            if (replymodel == null)
            {
                return HttpNotFound();
            }
            return View(replymodel);
        }

        //
        // POST: /Reply/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ReplyModel replymodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(replymodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(replymodel);
        }

        //
        // GET: /Reply/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ReplyModel replymodel = db.Replys.Find(id);
            if (replymodel == null)
            {
                return HttpNotFound();
            }
            return View(replymodel);
        }

        //
        // POST: /Reply/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReplyModel replymodel = db.Replys.Find(id);
            db.Replys.Remove(replymodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}