using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunTakipSistemiMvc5.Models.Entitiy;
using PagedList;
using PagedList.Mvc;
namespace UrunTakipSistemiMvc5.Controllers
{
    public class MusteriController : Controller
    {
        DbMvcStokEntities1 db = new DbMvcStokEntities1 ();
        // GET: Musteri
        public ActionResult Index(int sayfa=1)
        {
            var musteri = db.tbl_musteriler.Where(x => x.mus_durum == true).ToList().ToPagedList(sayfa, 5);
            return View(musteri);
        }

        [HttpGet]
        public ActionResult MusteriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MusteriEkle(tbl_musteriler p)
        {
            if(!ModelState.IsValid)
            {
                return View("MusteriEkle");
            }

            p.mus_durum = true;
            db.tbl_musteriler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSil(int id)
        {
            var musteri = db.tbl_musteriler.Find(id);
            musteri.mus_durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var mus = db.tbl_musteriler.Find(id);
            return View("MusteriGetir",mus);
        }

        [HttpGet]
        public ActionResult MusteriGuncelle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MusteriGuncelle(tbl_musteriler p)
        {
            var mus = db.tbl_musteriler.Find(p.mus_id);
            mus.mus_ad = p.mus_ad;
            mus.mus_soyad = p.mus_soyad;
            mus.mus_sehir = p.mus_sehir;
            mus.mus_bakiye = p.mus_bakiye;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
} 