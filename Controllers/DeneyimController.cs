using Mvc5Cv.Models.Entity;
using Mvc5Cv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5Cv.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim

        DeneyimRepository repo = new DeneyimRepository(); //Burda nesne oluşturduk ve deneyimrepo su genericten kalıtım aldığından generiğin tüm metodlarınıda burada kullanabileceğiz.
        public ActionResult Index()
        {
            var deger = repo.List();
            return View(deger);
        }
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeneyimEkle(TblDeneyimlerim p1)
        {
            repo.Tadd(p1);
            return RedirectToAction("Index");
        }

        public ActionResult DeneyimSil(int id)
        {
            var deger = repo.TGet(id); //burada değer in üstüne gelince zaten TblDeneyimlerim tablosu geliyor . oradaki değerleri tutacak demek.
            repo.TDelete(deger);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            var deger = repo.TGet(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult DeneyimGetir(TblDeneyimlerim p1)
        {
            var deger = repo.TGet(p1.Id); //httpgetteki id nin bilgilerini alıyor.
            deger.Baslik = p1.Baslik;
            deger.AltBaslik = p1.AltBaslik;
            deger.Tarih = p1.Tarih;
            deger.Aciklama = p1.Aciklama;
            repo.TUpdate(deger);
            return RedirectToAction("Index");
        }
    }
}