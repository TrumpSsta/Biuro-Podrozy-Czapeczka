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
    public class KlientsController : Controller
    {
        private Czapeczka db = new Czapeczka();

        // GET: Klients
        public ActionResult Index()
        {   
            return View(db.Klient.ToList());
        }

        // GET: Klients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klient klient = db.Klient.Find(id);
            if (klient == null)
            {
                return HttpNotFound();
            }
            return View(klient);
        }
        public ActionResult AdvencedDetails(int? id )
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klient klient = db.Klient.Find(id);
            if (klient == null)
            {
                return HttpNotFound();
            }
           
            var tuple = new Tuple<Klient, List<Udzial>, List<Wycieczka>>(klient, db.Udzial.ToList(), db.Wycieczka.ToList());
            return View(tuple);


            
        }
        public ActionResult Tranzakcja(int? id )
        {
            ViewBag.IdKlienta = new SelectList(db.Klient, "IdKlienta", "Imię");
            ViewBag.IdWycieczki = new SelectList(db.Wycieczka, "IdWycieczki", "Panstwo");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klient klient = db.Klient.Find(id);
            if (klient == null)
            {
                return HttpNotFound();
            }

            var tuple = new Tuple<Klient>(klient) ;
            return View(tuple);



        }

        // GET: Klients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Klients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include =
            "IdKlienta,Imię,Nazwisko,Mail,Telefon,Suma")] Klient klient)
        {
            string msg = string.Empty;
            ViewBag.Exception = null;
            if (ModelState.IsValid)
            {
                db.Klient.Add(klient);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    if (e.InnerException == null)
                    { msg = "Zle dane"; }
                    else
                    { msg = e.InnerException.InnerException.Message; }
                    ViewBag.Exception = msg;
                    return View(klient);
                }
                return RedirectToAction("Index");
            }
            return View(klient);
        }

        // GET: Klients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klient klient = db.Klient.Find(id);
            if (klient == null)
            {
                return HttpNotFound();
            }
            return View(klient);
        }

        // POST: Klients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdKlienta,Imię,Nazwisko,Mail,Telefon,Suma")] Klient klient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(klient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(klient);
        }

        // GET: Klients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klient klient = db.Klient.Find(id);
            if (klient == null)
            {
                return HttpNotFound();
            }
            return View(klient);
        }

        // POST: Klients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Klient klient = db.Klient.Find(id);
            db.Klient.Remove(klient);
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
