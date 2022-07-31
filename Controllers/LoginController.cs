using Mvc5Cv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Mvc5Cv.Controllers
{
    //[Authorize]
    [AllowAnonymous] //Bunu diyerek login yapmadan erişilebilir yaptık. istisna tuttuk yani.
    public class LoginController : Controller
    {
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

        DbCvEntities db = new DbCvEntities();
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblAdmin p1)
        {
            var login = db.TblAdmin.FirstOrDefault(x => x.KullaniciAdi == p1.KullaniciAdi && x.Sifre == p1.Sifre);
            if (login!=null)
            {
                FormsAuthentication.SetAuthCookie(login.KullaniciAdi, false); //Buradaki kullanıcı sisteme tanıtılıyor. parantez içerisindede kullanıcı bilgilerinin ne olarak tutulacağını belirliyoruz.
                //Session["KullaniciAdi"] = login.KullaniciAdi.ToString(); //Burası olsada olur olmasada olur.
                return RedirectToAction("Index", "Deneyim"); //deneyimdeki index sayfasına gidecek giriş yapıldığında.
            }
            else
            {
                return RedirectToAction("Index", "Login"); //Bilgiler eşit değilse login içinde ındex calıssın.
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut(); //authenticationdan cıkış yap.
            Session.Abandon(); //oturumu terk et.
            return RedirectToAction("Index", "Login");
        }
    }
}