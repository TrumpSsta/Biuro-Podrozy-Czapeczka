using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BiuroPodrozyCzapeczka.Models
{
    public class RaportsController : Controller
    {
        // GET: Raports
        public ActionResult Index()
        {
            return View();
        }
    }
}