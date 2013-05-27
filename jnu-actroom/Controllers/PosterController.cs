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
    [ValidateInput(false)]
    public class PosterController : Controller
    {
        private PosterDBContext db = new PosterDBContext();


        public ActionResult addComment(int id = 0)
        {

            var replyContext = new ReplyDBContext();
            ReplyModel rModel = new ReplyModel();
            rModel.PoserId = id;
            rModel.Text = Request["replyText"] as string;
            rModel.UserId = new UsersContext().UserProfiles.Single(u=>u.UserName == User.Identity.Name).UserId;
            rModel.CreateTime = DateTime.Now;
            rModel.ModifyTime = DateTime.Now;
            replyContext.Replys.Add(rModel);
            replyContext.SaveChanges();
            return RedirectToAction("details/" + id);
        }
        //
        // GET: /Poster/

        public ActionResult Index()
        {

            return View(db.Posters.OrderByDescending(i=>i.PostTime).ToList());
        }

        //
        // GET: /Poster/Details/5

        public ActionResult Details(int id = 0)
        {
            PosterModel postermodel = db.Posters.Find(id);
            if (postermodel == null)
            {
                return HttpNotFound();
            }
            return View(postermodel);
        }

        //
        // GET: /Poster/Create

        public ActionResult Create()
        {
            ViewBag.isNewRecord = true;
            return View();
        }

        //
        // POST: /Poster/Create

        [HttpPost]
    
        [ValidateInput(false)]
        public ActionResult Create(PosterModel postermodel)
        {
            if (ModelState.IsValid)
            {
                
                //Server.HtmlEncode(postermodel.Text);
                postermodel.PostTime = DateTime.Now;
                postermodel.ModifyTime = DateTime.Now;
                postermodel.UserId = new UsersContext().UserProfiles.Single(u => u.UserName == User.Identity.Name).UserId;
                db.Posters.Add(postermodel);
                

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(postermodel);
        }

        //
        // GET: /Poster/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PosterModel postermodel = db.Posters.Find(id);
            ViewBag.isNewRecord = false;
            if (postermodel == null)
            {
                return HttpNotFound();
            }
            return View( postermodel);
        }

        //
        // POST: /Poster/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PosterModel postermodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postermodel).State = EntityState.Modified;
                postermodel.ModifyTime = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(postermodel);
        }

        //
        // GET: /Poster/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PosterModel postermodel = db.Posters.Find(id);
            if (postermodel == null)
            {
                return HttpNotFound();
            }
            return View(postermodel);
        }

        //
        // POST: /Poster/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PosterModel postermodel = db.Posters.Find(id);
            db.Posters.Remove(postermodel);
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