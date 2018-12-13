using BiuroPodrozyCzapeczka.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BiuroPodrozyCzapeczka.Controllers
{
    public class KlientUdzialController : Controller
    {
        private Czapeczka db = new Czapeczka();
        // GET: KlientUdzial
        public ActionResult Index()
        {
            KlientUdzialViewModel model = new KlientUdzialViewModel();
            model.Klient = db.Klient.ToList();
            model.Udzial = db.Udzial.ToList();
            return View(model);
        }

        // GET: KlientUdzial/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: KlientUdzial/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Transakcja(int? id)
        {
            string msg = string.Empty;
            ViewBag.Exception = null;
            Udzial udzial = db.Udzial.Find(id);
            try
            {
                db.Entry(udzial).State = EntityState.Modified;

                int res = db.Database.ExecuteSqlCommand(
                         @"UPDATE Udzial SET IloscOsob = @p0 WHERE Id = @p1"
);
                db.SaveChanges();
                    return RedirectToAction("Index");
            }
            catch (Exception e )
            {
                if (e.InnerException == null)
                { msg = "Zle dane"; }
                else
                { msg = e.InnerException.InnerException.Message; }
                ViewBag.Exception = msg;
               
            }

            ViewBag.IdKlienta = new SelectList(db.Klient, "IdKlienta", "IdKlienta");
            ViewBag.IdWycieczki = new SelectList(db.Wycieczka, "IdWycieczki", "IdWycieczki");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klient klient = db.Klient.Find(id);
            if (klient == null)
            {
                return HttpNotFound();
            }
            List<Klient> t = new List<Klient>();
            t.Add(db.Klient.Find(id)); ;
            KlientUdzialViewModel model = new KlientUdzialViewModel();
            model.Klient1 = db.Klient.Find(id);
            return View(model);
        }

        // POST: KlientUdzial/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: KlientUdzial/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: KlientUdzial/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: KlientUdzial/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: KlientUdzial/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
