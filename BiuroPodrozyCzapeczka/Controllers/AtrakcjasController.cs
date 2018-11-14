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
    public class AtrakcjasController : Controller
    {
        private Czapeczka db = new Czapeczka();

        // GET: Atrakcjas
        public ActionResult Index()
        {
            return View(db.Atrakcja.ToList());
        }

        // GET: Atrakcjas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atrakcja atrakcja = db.Atrakcja.Find(id);
            if (atrakcja == null)
            {
                return HttpNotFound();
            }
            return View(atrakcja);
        }

        // GET: Atrakcjas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Atrakcjas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAtrakcji,NazwaAtrakcji,AdresAtrakcji,CenaAtrakcji")] Atrakcja atrakcja)
        {
            if (ModelState.IsValid)
            {
                db.Atrakcja.Add(atrakcja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(atrakcja);
        }

        // GET: Atrakcjas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atrakcja atrakcja = db.Atrakcja.Find(id);
            if (atrakcja == null)
            {
                return HttpNotFound();
            }
            return View(atrakcja);
        }

        // POST: Atrakcjas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAtrakcji,NazwaAtrakcji,AdresAtrakcji,CenaAtrakcji")] Atrakcja atrakcja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atrakcja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(atrakcja);
        }

        // GET: Atrakcjas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atrakcja atrakcja = db.Atrakcja.Find(id);
            if (atrakcja == null)
            {
                return HttpNotFound();
            }
            return View(atrakcja);
        }

        // POST: Atrakcjas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Atrakcja atrakcja = db.Atrakcja.Find(id);
            db.Atrakcja.Remove(atrakcja);
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
