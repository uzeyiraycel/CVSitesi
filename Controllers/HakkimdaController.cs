using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5Cv.Models.Entity;
using Mvc5Cv.Repositories;

namespace Mvc5Cv.Controllers
{
    public class HakkimdaController : Controller
    {
        HakkimdaRepository repo = new HakkimdaRepository();
        public ActionResult Index()
        {
            var deger = repo.List();
            return View(deger);
        }

        [HttpGet]
        public ActionResult HakkimdaGetir(int id)
        {
            var deger = repo.TGet(id);
            return View(deger);
        }

        [HttpPost]
        public ActionResult HakkimdaGetir(TblHakkimda p1)
        {
            var deger = repo.TGet(p1.Id);
            deger.Ad = p1.Ad;
            deger.Soyad = p1.Soyad;
            deger.Adres = p1.Adres;
            deger.Mail = p1.Mail;
            deger.Telefon = p1.Telefon;
            deger.Aciklama = p1.Aciklama;
            deger.Resim = p1.Resim;
            repo.TUpdate(deger);
            return RedirectToAction("Index");
        }
    }
}