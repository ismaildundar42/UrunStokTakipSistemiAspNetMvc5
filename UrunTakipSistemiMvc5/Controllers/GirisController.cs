using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UrunTakipSistemiMvc5.Models.Entitiy;
namespace UrunTakipSistemiMvc5.Controllers
{
    public class GirisController : Controller
    {
        DbMvcStokEntities1 db = new DbMvcStokEntities1 ();
        // GET: Giris
        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(tbl_adminler p)
        {
            var bilgiler = db.tbl_adminler.FirstOrDefault(x => x.kullaniciAdi == p.kullaniciAdi && x.sifre == p.sifre);
            if(bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.kullaniciAdi, false);
                return RedirectToAction("Index", "Satis");
            }
            else
            {
                return View();
            }
            return View();
        }
    }
}