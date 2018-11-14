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
    public class PokojsController : Controller
    {
        private Czapeczka db = new Czapeczka();

        // GET: Pokojs
        public ActionResult Index()
        {
            var pokoj = db.Pokoj.Include(p => p.Hotel);
            return View(pokoj.ToList());
        }

        // GET: Pokojs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pokoj pokoj = db.Pokoj.Find(id);
            if (pokoj == null)
            {
                return HttpNotFound();
            }
            return View(pokoj);
        }

        // GET: Pokojs/Create
        public ActionResult Create()
        {
            ViewBag.IdHotelu = new SelectList(db.Hotel, "IdHotelu", "NazwaHotelu");
            return View();
        }

        // POST: Pokojs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPokoju,IdHotelu,Liczba,Cena,Kaucja,Rezerwacja,WolnyData,KoniecWolnego")] Pokoj pokoj)
        {
            if (ModelState.IsValid)
            {
                db.Pokoj.Add(pokoj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdHotelu = new SelectList(db.Hotel, "IdHotelu", "NazwaHotelu", pokoj.IdHotelu);
            return View(pokoj);
        }

        // GET: Pokojs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pokoj pokoj = db.Pokoj.Find(id);
            if (pokoj == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdHotelu = new SelectList(db.Hotel, "IdHotelu", "NazwaHotelu", pokoj.IdHotelu);
            return View(pokoj);
        }

        // POST: Pokojs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPokoju,IdHotelu,Liczba,Cena,Kaucja,Rezerwacja,WolnyData,KoniecWolnego")] Pokoj pokoj)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pokoj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdHotelu = new SelectList(db.Hotel, "IdHotelu", "NazwaHotelu", pokoj.IdHotelu);
            return View(pokoj);
        }

        // GET: Pokojs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pokoj pokoj = db.Pokoj.Find(id);
            if (pokoj == null)
            {
                return HttpNotFound();
            }
            return View(pokoj);
        }

        // POST: Pokojs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pokoj pokoj = db.Pokoj.Find(id);
            db.Pokoj.Remove(pokoj);
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
