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
    public class PracowniksController : Controller
    {
        private Czapeczka db = new Czapeczka();

        // GET: Pracowniks
        public ActionResult Index()
        {
            var pracownik = db.Pracownik.Include(p => p.Placowka);
            return View(pracownik.ToList());
        }

        // GET: Pracowniks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pracownik pracownik = db.Pracownik.Find(id);
            if (pracownik == null)
            {
                return HttpNotFound();
            }
            return View(pracownik);
        }

        // GET: Pracowniks/Create
        public ActionResult Create()
        {
            ViewBag.IdPlacowki = new SelectList(db.Placowka, "IdPlacowki", "Wojewodztwo");
            return View();
        }

        // POST: Pracowniks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPracownika,IdPlacowki,Imie,Nazwisko,telefon,mail,pensja")] Pracownik pracownik)
        {
            if (ModelState.IsValid)
            {
                db.Pracownik.Add(pracownik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPlacowki = new SelectList(db.Placowka, "IdPlacowki", "Wojewodztwo", pracownik.IdPlacowki);
            return View(pracownik);
        }

        // GET: Pracowniks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pracownik pracownik = db.Pracownik.Find(id);
            if (pracownik == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPlacowki = new SelectList(db.Placowka, "IdPlacowki", "Wojewodztwo", pracownik.IdPlacowki);
            return View(pracownik);
        }

        // POST: Pracowniks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPracownika,IdPlacowki,Imie,Nazwisko,telefon,mail,pensja")] Pracownik pracownik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pracownik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPlacowki = new SelectList(db.Placowka, "IdPlacowki", "Wojewodztwo", pracownik.IdPlacowki);
            return View(pracownik);
        }

        // GET: Pracowniks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pracownik pracownik = db.Pracownik.Find(id);
            if (pracownik == null)
            {
                return HttpNotFound();
            }
            return View(pracownik);
        }

        // POST: Pracowniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pracownik pracownik = db.Pracownik.Find(id);
            db.Pracownik.Remove(pracownik);
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
