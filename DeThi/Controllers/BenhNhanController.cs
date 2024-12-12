using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DeThi.Models;

namespace DeThi.Controllers
{
    public class BenhNhanController : Controller
    {
        private QLBVEntities db = new QLBVEntities();

        // GET: BenhNhan
        public ActionResult Index()
        {
            return View(db.BenhNhan.ToList());
        }

        // GET: BenhNhan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BenhNhan benhNhan = db.BenhNhan.Find(id);
            if (benhNhan == null)
            {
                return HttpNotFound();
            }
            return View(benhNhan);
        }

        // GET: BenhNhan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BenhNhan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaBN,HoTen,NgaySinh,GioiTinh,DienThoai")] BenhNhan benhNhan)
        {
            if (ModelState.IsValid)
            {
                db.BenhNhan.Add(benhNhan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(benhNhan);
        }

        // GET: BenhNhan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BenhNhan benhNhan = db.BenhNhan.Find(id);
            if (benhNhan == null)
            {
                return HttpNotFound();
            }
            return View(benhNhan);
        }

        // POST: BenhNhan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaBN,HoTen,NgaySinh,GioiTinh,DienThoai")] BenhNhan benhNhan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(benhNhan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(benhNhan);
        }

        // GET: BenhNhan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BenhNhan benhNhan = db.BenhNhan.Find(id);
            if (benhNhan == null)
            {
                return HttpNotFound();
            }
            return View(benhNhan);
        }

        // POST: BenhNhan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BenhNhan benhNhan = db.BenhNhan.Find(id);
            db.BenhNhan.Remove(benhNhan);
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
