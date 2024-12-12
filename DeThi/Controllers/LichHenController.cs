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
    public class LichHenController : Controller
    {
        private QLBVEntities db = new QLBVEntities();

        public ActionResult Index(string TenBN, string TenBS)
        {
            var lichHen = db.LichHen.Include(d => d.BenhNhan).Include(d => d.BacSi).Where(c => c.BenhNhan.HoTen.Contains(TenBN));
            ViewBag.TenBS = db.LichHen.Include("BacSi").Where(c => c.BacSi.TenBS == TenBS).Select(
                g => new SelectListItem
                {
                    Text = g.BacSi.TenBS,
                    Value = g.BacSi.TenBS
                }
            ).ToList();
            return View(lichHen.ToList());
        }


        // GET: LichHen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichHen lichHen = db.LichHen.Find(id);
            if (lichHen == null)
            {
                return HttpNotFound();
            }
            return View(lichHen);
        }

        // GET: LichHen/Create
        public ActionResult Create()
        {
            ViewBag.MaBS = new SelectList(db.BacSi, "MaBS", "TenBS");
            ViewBag.MaBN = new SelectList(db.BenhNhan, "MaBN", "HoTen");
            return View();
        }

        // POST: LichHen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLH,MaBN,MaBS,NgayHen,LyDo")] LichHen lichHen)
        {
            if (ModelState.IsValid)
            {
                db.LichHen.Add(lichHen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaBS = new SelectList(db.BacSi, "MaBS", "TenBS", lichHen.MaBS);
            ViewBag.MaBN = new SelectList(db.BenhNhan, "MaBN", "HoTen", lichHen.MaBN);
            return View(lichHen);
        }

        // GET: LichHen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichHen lichHen = db.LichHen.Find(id);
            if (lichHen == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaBS = new SelectList(db.BacSi, "MaBS", "TenBS", lichHen.MaBS);
            ViewBag.MaBN = new SelectList(db.BenhNhan, "MaBN", "HoTen", lichHen.MaBN);
            return View(lichHen);
        }

        // POST: LichHen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLH,MaBN,MaBS,NgayHen,LyDo")] LichHen lichHen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lichHen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaBS = new SelectList(db.BacSi, "MaBS", "TenBS", lichHen.MaBS);
            ViewBag.MaBN = new SelectList(db.BenhNhan, "MaBN", "HoTen", lichHen.MaBN);
            return View(lichHen);
        }

        // GET: LichHen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichHen lichHen = db.LichHen.Find(id);
            if (lichHen == null)
            {
                return HttpNotFound();
            }
            return View(lichHen);
        }

        // POST: LichHen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LichHen lichHen = db.LichHen.Find(id);
            db.LichHen.Remove(lichHen);
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
