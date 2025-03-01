using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunTakipSistemiMvc5.Models.Entitiy;
namespace UrunTakipSistemiMvc5.Controllers
{
    public class KategoriController : Controller
    {
        DbMvcStokEntities1 db = new DbMvcStokEntities1();
        // GET: Kategori
        public ActionResult Index()
        {
            var kategoriler = db.tbl_kategoriler.ToList();
            return View(kategoriler);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(tbl_kategoriler p)
        {
            db.tbl_kategoriler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var kate = db.tbl_kategoriler.Find(id);
            db.tbl_kategoriler.Remove(kate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var kate = db.tbl_kategoriler.Find(id);
            return View("KategoriGetir", kate);
        }

        public ActionResult KategoriGuncelle(tbl_kategoriler k)
        {
            var kate = db.tbl_kategoriler.Find(k.kategori_id);
            kate.kategori_ad = k.kategori_ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}