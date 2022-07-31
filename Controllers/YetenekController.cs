using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5Cv.Models.Entity;
using Mvc5Cv.Repositories;

namespace Mvc5Cv.Controllers
{
    public class YetenekController : Controller
    {
        YetenekRepository repo = new YetenekRepository();
        public ActionResult Index()
        {
            var deger = repo.List();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YetenekEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YetenekEkle(TblYeteneklerim p1)
        {
            repo.Tadd(p1);
            return RedirectToAction("Index");
        }
        public ActionResult YetenekSil(int id)
        {
            var deger = repo.TGet(id);
            repo.TDelete(deger);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekGetir(int id)
        {
            var deger = repo.TGet(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult YetenekGetir(TblYeteneklerim p1)
        {
            var deger = repo.TGet(p1.Id);
            deger.Yetenek = p1.Yetenek;
            deger.Oran = p1.Oran;
            repo.TUpdate(deger);
            return RedirectToAction("Index");
        }
    }
}