using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5Cv.Models.Entity;
using Mvc5Cv.Repositories;

namespace Mvc5Cv.Controllers
{
    public class AdminController : Controller
    {
        GenericRepository<TblAdmin> repo = new GenericRepository<TblAdmin>();

        public ActionResult Index()
        {
            var deger = repo.List();
            return View(deger);
        }
        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminEkle(TblAdmin p1)
        {
            repo.Tadd(p1);
            return RedirectToAction("Index");
        }

        public ActionResult AdminSil(int id)
        {
            var deger = repo.TGet(id);
            repo.TDelete(deger);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminGetir(int id)
        {
            var deger = repo.TGet(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult AdminGetir(TblAdmin p1)
        {
            var deger = repo.TGet(p1.Id); //httpgetteki id nin bilgilerini alıyor.
            deger.KullaniciAdi = p1.KullaniciAdi;
            deger.Sifre = p1.Sifre;
            repo.TUpdate(deger);
            return RedirectToAction("Index");
        }
    }
}