using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5Cv.Models.Entity;

namespace Mvc5Cv.Controllers
{
    [AllowAnonymous] //Bunu diyerek login yapmadan erişilebilir yaptık. istisna tuttuk yani.
    public class DefaultController : Controller
    {
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index() //aşağıdaki deneyim partial view ini buradaki index view inde kullandık.
        {
            var degerler = db.TblHakkimda.ToList();
            return View(degerler);
        }

        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.TblSosyalMedya.Where(x => x.Durum == true).ToList(); //Buradada durumu sadece true olanları gösterecek.
            return PartialView(sosyalmedya);
        }

        //* partialviewresult nedir?: MVC projelerde bazı durumlarda View dosyalarının içerisinde başka bir View dosyası çağırabiliriz.
        //* hakkımda sayfasında sosyal medya kısımları var . orayı başka tablodan alacağız ancak aynı sayfada olacak. yani bir view de 2 model olacak bunun için kullanırız.
        public PartialViewResult Deneyim()
        {
            var deneyimler = db.TblDeneyimlerim.ToList();
            return PartialView(deneyimler);
        }

        //Partialviewresult: controllerda view ini oluşturup view kısmında front end ini yaptıktann sonra hangi view da kullanacaksak o view da @html.partial("") veya @html.action("") diyip çağırıyoruz.

        public PartialViewResult Egitimlerim()
        {
            var egitimler = db.TblEgitimlerim.ToList();
            return PartialView(egitimler);
        }
        public PartialViewResult Yeteneklerim()
        {
            var yetenekler = db.TblYeteneklerim.ToList();
            return PartialView(yetenekler);
        }
        public PartialViewResult Hobilerim()
        {
            var hobiler = db.TblHobilerim.ToList();
            return PartialView(hobiler);
        }

        public PartialViewResult Sertifikalarim()
        {
            var sertifikalar = db.TblSertifikalarim.ToList();
            return PartialView(sertifikalar);
        }

        [HttpGet]
        public PartialViewResult Iletisim()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Iletisim(TblIletisim p1)
        {
            p1.Tarih = DateTime.Now; //Tarihi burada ekledik.
            //p1.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString()); //böyle deseydik olurdu. bu kullanım daha yaygın ama bunu öğren.
            db.TblIletisim.Add(p1);
            db.SaveChanges();
            return PartialView();
        }
    }
}