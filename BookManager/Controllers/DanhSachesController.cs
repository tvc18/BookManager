using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookManager.Models;

namespace BookManager.Controllers
{
    public class DanhSachesController : Controller
    {
        private book db = new book();

        // GET: DanhSaches
        public ActionResult Index()
        {
            return View(db.DanhSaches.ToList());
        }

        // GET: DanhSaches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhSach danhSach = db.DanhSaches.Find(id);
            if (danhSach == null)
            {
                return HttpNotFound();
            }
            return View(danhSach);
        }

        // GET: DanhSaches/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: DanhSaches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Author,Title,Description,Image,Price")] DanhSach danhSach)
        {
            if (ModelState.IsValid)
            {
                db.DanhSaches.Add(danhSach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(danhSach);
        }

        // GET: DanhSaches/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhSach danhSach = db.DanhSaches.Find(id);
            if (danhSach == null)
            {
                return HttpNotFound();
            }
            return View(danhSach);
        }

        // POST: DanhSaches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Author,Title,Description,Image,Price")] DanhSach danhSach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhSach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(danhSach);
        }

        // GET: DanhSaches/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhSach danhSach = db.DanhSaches.Find(id);
            if (danhSach == null)
            {
                return HttpNotFound();
            }
            return View(danhSach);
        }

        // POST: DanhSaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DanhSach danhSach = db.DanhSaches.Find(id);
            db.DanhSaches.Remove(danhSach);
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

        [Authorize]
        public ActionResult Buy(int id)
        {
            DanhSach danhSach = db.DanhSaches.SingleOrDefault(p => p.ID == id);
            if(danhSach==null)
            {
                return HttpNotFound();
            }
            return View(danhSach);
        }
    }
}
