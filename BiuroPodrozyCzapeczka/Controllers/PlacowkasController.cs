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
    public class PlacowkasController : Controller
    {
        private Czapeczka db = new Czapeczka();

        // GET: Placowkas
        public ActionResult Index()
        {
            return View(db.Placowka.ToList());
        }

        // GET: Placowkas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Placowka placowka = db.Placowka.Find(id);
            if (placowka == null)
            {
                return HttpNotFound();
            }
            return View(placowka);
        }

        // GET: Placowkas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Placowkas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPlacowki,Wojewodztwo,Miasto,Ulica,Numer,IloscPracownikow")] Placowka placowka)
        {
            if (ModelState.IsValid)
            {
                db.Placowka.Add(placowka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(placowka);
        }

        // GET: Placowkas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Placowka placowka = db.Placowka.Find(id);
            if (placowka == null)
            {
                return HttpNotFound();
            }
            return View(placowka);
        }

        // POST: Placowkas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPlacowki,Wojewodztwo,Miasto,Ulica,Numer,IloscPracownikow")] Placowka placowka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(placowka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(placowka);
        }

        // GET: Placowkas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Placowka placowka = db.Placowka.Find(id);
            if (placowka == null)
            {
                return HttpNotFound();
            }
            return View(placowka);
        }

        // POST: Placowkas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Placowka placowka = db.Placowka.Find(id);
            db.Placowka.Remove(placowka);
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
