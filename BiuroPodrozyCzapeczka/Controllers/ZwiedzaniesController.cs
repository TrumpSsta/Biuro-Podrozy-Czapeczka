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
    public class ZwiedzaniesController : Controller
    {
        private Czapeczka db = new Czapeczka();

        // GET: Zwiedzanies
        public ActionResult Index()
        {
            var zwiedzanie = db.Zwiedzanie.Include(z => z.Atrakcja).Include(z => z.Wycieczka);
            return View(zwiedzanie.ToList());
        }

        // GET: Zwiedzanies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zwiedzanie zwiedzanie = db.Zwiedzanie.Find(id);
            if (zwiedzanie == null)
            {
                return HttpNotFound();
            }
            return View(zwiedzanie);
        }

        // GET: Zwiedzanies/Create
        public ActionResult Create()
        {
            ViewBag.IdAtrakcji = new SelectList(db.Atrakcja, "IdAtrakcji", "NazwaAtrakcji");
            ViewBag.IdWycieczki = new SelectList(db.Wycieczka, "IdWycieczki", "Panstwo");
            return View();
        }

        // POST: Zwiedzanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdZwiedzania,IdWycieczki,IdAtrakcji,Miasto,CenaZwiedzania,DataZwiedzania")] Zwiedzanie zwiedzanie)
        {
            if (ModelState.IsValid)
            {
                db.Zwiedzanie.Add(zwiedzanie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAtrakcji = new SelectList(db.Atrakcja, "IdAtrakcji", "NazwaAtrakcji", zwiedzanie.IdAtrakcji);
            ViewBag.IdWycieczki = new SelectList(db.Wycieczka, "IdWycieczki", "Panstwo", zwiedzanie.IdWycieczki);
            return View(zwiedzanie);
        }

        // GET: Zwiedzanies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zwiedzanie zwiedzanie = db.Zwiedzanie.Find(id);
            if (zwiedzanie == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAtrakcji = new SelectList(db.Atrakcja, "IdAtrakcji", "NazwaAtrakcji", zwiedzanie.IdAtrakcji);
            ViewBag.IdWycieczki = new SelectList(db.Wycieczka, "IdWycieczki", "Panstwo", zwiedzanie.IdWycieczki);
            return View(zwiedzanie);
        }

        // POST: Zwiedzanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdZwiedzania,IdWycieczki,IdAtrakcji,Miasto,CenaZwiedzania,DataZwiedzania")] Zwiedzanie zwiedzanie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zwiedzanie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAtrakcji = new SelectList(db.Atrakcja, "IdAtrakcji", "NazwaAtrakcji", zwiedzanie.IdAtrakcji);
            ViewBag.IdWycieczki = new SelectList(db.Wycieczka, "IdWycieczki", "Panstwo", zwiedzanie.IdWycieczki);
            return View(zwiedzanie);
        }

        // GET: Zwiedzanies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zwiedzanie zwiedzanie = db.Zwiedzanie.Find(id);
            if (zwiedzanie == null)
            {
                return HttpNotFound();
            }
            return View(zwiedzanie);
        }

        // POST: Zwiedzanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zwiedzanie zwiedzanie = db.Zwiedzanie.Find(id);
            db.Zwiedzanie.Remove(zwiedzanie);
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
