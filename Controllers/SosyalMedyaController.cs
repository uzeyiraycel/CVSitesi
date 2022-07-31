using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5Cv.Models.Entity;
using Mvc5Cv.Repositories;

namespace Mvc5Cv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        GenericRepository<TblSosyalMedya> repo = new GenericRepository<TblSosyalMedya>(); //Burada sosyalmedyanın direk repository si olmadığından generic repo dan aldık nesneyi.

        public ActionResult Index()
        {
            var veriler = repo.List();
            return View(veriler);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(TblSosyalMedya p1)
        {
            repo.Tadd(p1);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SayfaGetir(int id)
        {
            var hesap = repo.TGet(id);
            return View(hesap);
        }
        [HttpPost]
        public ActionResult SayfaGetir(TblSosyalMedya p1)
        {
            var hesap = repo.TGet(p1.Id);
            hesap.Ad = p1.Ad;
            hesap.Durum = true; //sosyal medya güncellendiği zaman false ise true olacak.
            hesap.Link = p1.Link;
            hesap.Icon = p1.Icon;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id) //hesabı silmenin başka türünü kullandık. silmeyecekte tüm alanları pasif yapacak.
        {
            var hesap = repo.TGet(id);
            hesap.Durum = false;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }
    }
}