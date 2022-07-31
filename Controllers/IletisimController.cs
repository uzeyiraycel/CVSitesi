using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5Cv.Models.Entity;
using Mvc5Cv.Repositories;

namespace Mvc5Cv.Controllers
{
    public class IletisimController : Controller
    {
        IletisimRepository repo = new IletisimRepository();
        public ActionResult Index()
        {
            var deger = repo.List();
            return View(deger);
        }
    }
}