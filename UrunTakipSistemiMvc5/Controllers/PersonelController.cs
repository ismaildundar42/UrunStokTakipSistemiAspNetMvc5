using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunTakipSistemiMvc5.Models.Entitiy;
namespace UrunTakipSistemiMvc5.Controllers
{
    public class PersonelController : Controller
    {
        DbMvcStokEntities1 db = new DbMvcStokEntities1 ();
        // GET: Personel
        public ActionResult Index()
        {
            var perso = db.tbl_personeller.Where(x => x.per_durum == true).ToList();
            return View(perso);
        }
        public ActionResult PersonelSil(int id)
        {
            var perso = db.tbl_personeller.Find (id);
            perso.per_durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult PersonelGetir(int id)
        {
            var perso = db.tbl_personeller.Find(id);
            return View("PersonelGetir", perso);
        }
        [HttpGet]
        public ActionResult PersonelGuncelle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PersonelGuncelle(tbl_personeller p)
        {
            var perso = db.tbl_personeller.Find(p.per_id);
            perso.per_ad = p.per_ad;
            perso.per_soyad = p.per_soyad;
            perso.per_departman = p.per_departman;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(tbl_personeller p)
        {
            var perso = db.tbl_personeller.Add(p);
            perso.per_durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}