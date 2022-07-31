using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5Cv.Models.Entity;
using Mvc5Cv.Repositories;

namespace Mvc5Cv.Controllers
{
    public class SertifikaController : Controller
    {
        SertifikaRepository repo = new SertifikaRepository();
        public ActionResult Index()
        {
            var deger = repo.List();
            return View(deger);
        }
        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var deger = repo.TGet(id);
            ViewBag.kimlik = deger.Id; //silme butonunu getir sayfasına koyacağımız için burdan id getirttik.önceden viewde direk foreach döngüsünde hallediyorduk şimdi güncelleme sayfasında olacak sil butonu.
            return View(deger);
        }
        [HttpPost]
        public ActionResult SertifikaGetir(TblSertifikalarim p1)
        {
            var deger = repo.TGet(p1.Id);
            deger.Tarih = p1.Tarih;
            deger.Aciklama = p1.Aciklama;
            repo.TUpdate(deger);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SertifikaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SertifikaEkle(TblSertifikalarim p1)
        {
            repo.Tadd(p1);
            return RedirectToAction("Index");
        }
        public ActionResult SertifikaSil(int id)
        {
            var deger = repo.TGet(id);
            repo.TDelete(deger);
            return RedirectToAction("Index");
        }
    }
}