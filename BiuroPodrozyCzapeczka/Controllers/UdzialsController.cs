using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BiuroPodrozyCzapeczka.Models;

namespace BiuroPodrozyCzapeczka.Controllers
{
    public class UdzialsController : Controller
    {
        private Czapeczka db = new Czapeczka();

        // GET: Udzials
        public ActionResult Index()
        {
            var udzial = db.Udzial.Include(u => u.Klient).Include(u => u.Wycieczka);
            return View(udzial.ToList());
        }

        // GET: Udzials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Udzial udzial = db.Udzial.Find(id);
            if (udzial == null)
            {
                return HttpNotFound();
            }
            return View(udzial);
        }

        // GET: Udzials/Create
        public ActionResult Create()
        {
            ViewBag.IdKlienta = new SelectList(db.Klient, "IdKlienta", "Imię");
            ViewBag.IdWycieczki = new SelectList(db.Wycieczka, "IdWycieczki", "Panstwo");
            return View();
        }

        // POST: Udzials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUdzialu,IdWycieczki,IdKlienta,IloscOsob,Wplacone")] Udzial udzial)
        {
            if (ModelState.IsValid)
            {
                db.Udzial.Add(udzial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdKlienta = new SelectList(db.Klient, "IdKlienta", "Imię", udzial.IdKlienta);
            ViewBag.IdWycieczki = new SelectList(db.Wycieczka, "IdWycieczki", "Panstwo", udzial.IdWycieczki);
            return View(udzial);
        }

        // GET: Udzials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Udzial udzial = db.Udzial.Find(id);
            if (udzial == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdKlienta = new SelectList(db.Klient, "IdKlienta", "Imię", udzial.IdKlienta);
            ViewBag.IdWycieczki = new SelectList(db.Wycieczka, "IdWycieczki", "Panstwo", udzial.IdWycieczki);
            return View(udzial);
        }

        // POST: Udzials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUdzialu,IdWycieczki,IdKlienta,IloscOsob,Wplacone")] Udzial udzial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(udzial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdKlienta = new SelectList(db.Klient, "IdKlienta", "Imię", udzial.IdKlienta);
            ViewBag.IdWycieczki = new SelectList(db.Wycieczka, "IdWycieczki", "Panstwo", udzial.IdWycieczki);
            return View(udzial);
        }

        // GET: Udzials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Udzial udzial = db.Udzial.Find(id);
            if (udzial == null)
            {
                return HttpNotFound();
            }
            return View(udzial);
        }

        // POST: Udzials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Udzial udzial = db.Udzial.Find(id);
            db.Udzial.Remove(udzial);
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
