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
    public class WycieczkasController : Controller
    {
        private Czapeczka db = new Czapeczka();

        // GET: Wycieczkas
        public ActionResult Index()
        {
            var wycieczka = db.Wycieczka.Include(w => w.Hotel).Include(w => w.Placowka);
            return View(wycieczka.ToList());
        }

        // GET: Wycieczkas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wycieczka wycieczka = db.Wycieczka.Find(id);
            if (wycieczka == null)
            {
                return HttpNotFound();
            }
            return View(wycieczka);
        }

        // GET: Wycieczkas/Create
        public ActionResult Create()
        {
            ViewBag.IdHotelu = new SelectList(db.Hotel, "IdHotelu", "NazwaHotelu");
            ViewBag.IdPlacowki = new SelectList(db.Placowka, "IdPlacowki", "Wojewodztwo");
            return View();
        }

        // POST: Wycieczkas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdWycieczki,IdPlacowki,IdHotelu,Panstwo,Miasto,Datawycieczki,Wydatki,Cena,KoniecWycieczki,DataWplaty")] Wycieczka wycieczka)
        {
            if (ModelState.IsValid)
            {
                db.Wycieczka.Add(wycieczka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdHotelu = new SelectList(db.Hotel, "IdHotelu", "NazwaHotelu", wycieczka.IdHotelu);
            ViewBag.IdPlacowki = new SelectList(db.Placowka, "IdPlacowki", "Wojewodztwo", wycieczka.IdPlacowki);
            return View(wycieczka);
        }

        // GET: Wycieczkas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wycieczka wycieczka = db.Wycieczka.Find(id);
            if (wycieczka == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdHotelu = new SelectList(db.Hotel, "IdHotelu", "NazwaHotelu", wycieczka.IdHotelu);
            ViewBag.IdPlacowki = new SelectList(db.Placowka, "IdPlacowki", "Wojewodztwo", wycieczka.IdPlacowki);
            return View(wycieczka);
        }
        public ActionResult Wycieczki_Raport()
        {
            var wycieczka = (from u in db.Udzial
                             join w in db.Wycieczka
                                        on u.IdWycieczki equals w.IdWycieczki
                             join h in db.Hotel
                                        on w.IdHotelu equals h.IdHotelu
                             join p in db.Pokoj
                                        on h.IdHotelu equals p.IdHotelu
                             where u.IloscOsob < p.Liczba
                             select new
                             {
                                   id =  w.IdWycieczki, 
                                  nh= h.NazwaHotelu, 
                                  idp= w.Panstwo,
                                  c=w.Cena
                                 
    }).ToList();

            var model = new List<WycieczkaHotel>();
            foreach (var element in wycieczka)
            {
             
                    model.Add(new WycieczkaHotel()
                    {
                    IdWycieczki = element.id,
                        NazwaHotelu = element.nh,
                        Panstwo = element.idp,
                        Cena= element.c

                    });
                
            }

            
            return View(model);
        }
        // POST: Wycieczkas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdWycieczki,IdPlacowki,IdHotelu,Panstwo,Miasto,Datawycieczki,Wydatki,Cena,KoniecWycieczki,DataWplaty")] Wycieczka wycieczka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wycieczka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdHotelu = new SelectList(db.Hotel, "IdHotelu", "NazwaHotelu", wycieczka.IdHotelu);
            ViewBag.IdPlacowki = new SelectList(db.Placowka, "IdPlacowki", "Wojewodztwo", wycieczka.IdPlacowki);
            return View(wycieczka);
        }

        // GET: Wycieczkas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wycieczka wycieczka = db.Wycieczka.Find(id);
            if (wycieczka == null)
            {
                return HttpNotFound();
            }
            return View(wycieczka);
        }

        // POST: Wycieczkas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wycieczka wycieczka = db.Wycieczka.Find(id);
            db.Wycieczka.Remove(wycieczka);
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
