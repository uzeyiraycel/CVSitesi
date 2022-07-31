using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5Cv.Models.Entity;
using Mvc5Cv.Repositories;

namespace Mvc5Cv.Controllers
{
    public class HobiController : Controller
    {
        HobiRepository repo = new HobiRepository();
        public ActionResult Index()
        {
            var deger = repo.List();
            return View(deger);
        }

        [HttpGet]
        public ActionResult HobiGetir(int id)
        {
            var deger = repo.TGet(id);
            return View(deger);
        }

        [HttpPost]
        public ActionResult HobiGetir(TblHobilerim p1)
        {
            var deger = repo.TGet(p1.Id);
            deger.Aciklama1 = p1.Aciklama1;
            deger.Aciklama2 = p1.Aciklama2;
            repo.TUpdate(deger);
            return RedirectToAction("Index");
        }
    }
}