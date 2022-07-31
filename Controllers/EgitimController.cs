using Mvc5Cv.Models.Entity;
using Mvc5Cv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5Cv.Controllers
{
    //[Authorize]
    public class EgitimController : Controller
    {
        EgitimRepository repo = new EgitimRepository();

        //[Authorize] //Login olmayan ındex sayfasını göremeyecek. Hata verecek.
        /*web.config dosyasındaki system.web kodu üstündeki alana <authentication mode="Forms">
            <forms loginUrl = "/Login/Index/" ></ forms >
        </ authentication > yazmayı unutma authorize nin çalışması için.*/

        /*AUTHORİZE İÇİN ÇOK ÖNEMLİ NOT: authorize 3 yerde tanımlanır. hangi sayfa üstünde tanımlarsak sadece o sayfaya giriş yapılmadan erişilemeyecek.
         eğer controller içindeki namespace alanının hemen altında tanımlarsak o controllara ait tüm sayfalar için giriş yapılmadan acılmayacak demek.
        son olarak ise en geniş olanı olan Global.asax dosyasında GlobalFilters.Filters.Add(new AuthorizeAttribute()); kodunu ekliyoruz.
        böylelikle projedeki tüm controllara giriş olmadan ulaşılamaz buna login controllarıda dahil. peki ulaşamadan nasıl giriş yapacağız ?
        onun yoluda şöyle. login olmadanda açılmasını istediğimiz alanları istisna tutmak istiyorsak o controlların namespace hemen altına 
        [AllowAnonymous] yazacağız böylelikle istisna tutup o sayfada giriş yapılmadan açılabilecektir. biz login ve default controlları için allowAnonymus yaptık*/
        public ActionResult Index()
        {
            var deger=repo.List();
            return View(deger);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(TblEgitimlerim p1)
        {
            if (!ModelState.IsValid) //validationdaki control tarafı. modeldurumu validation olmuyorsa yani doğrulama olmuyorsa işlem yapmadan view getir direk.
            {
                return View();
            }
            repo.Tadd(p1);
            return RedirectToAction("Index");
        }
        public ActionResult EgitimSil(int id)
        {
            var deger = repo.TGet(id);
            repo.TDelete(deger);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimGetir(int id)
        {
            var deger = repo.TGet(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult EgitimGetir(TblEgitimlerim P1)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var deger = repo.TGet(P1.Id);
            deger.Baslik = P1.Baslik;
            deger.AltBaslik1 = P1.AltBaslik1;
            deger.AltBaslik2 = P1.AltBaslik2;
            deger.Gno = P1.Gno;
            deger.Tarih = P1.Tarih;
            repo.TUpdate(deger);
            return RedirectToAction("Index");
        }
    }
}