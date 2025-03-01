using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunTakipSistemiMvc5.Models.Entitiy;
namespace UrunTakipSistemiMvc5.Controllers
{
    public class SatisController : Controller
    {
        DbMvcStokEntities1 db = new DbMvcStokEntities1();
        // GET: Satis
        public ActionResult Index()
        {
            var satislar = db.tbl_satislar.ToList();
            return View(satislar);
        }
        [HttpGet]
        public ActionResult SatisEkle()
        {
            // ürünler 
            List<SelectListItem> urun = (from x in db.tbl_urunler.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.urun_ad,
                                            Value = x.urun_id.ToString()
                                        }).ToList();
            ViewBag.dropdeger1 = urun;

            // müşteriler
            List<SelectListItem> musteriler = (from x in db.tbl_musteriler.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.mus_ad+' '+x.mus_soyad,
                                             Value = x.mus_id.ToString()
                                         }).ToList();
            ViewBag.dropdeger3 = musteriler;

            // personeller
            List<SelectListItem> personel = (from x in db.tbl_personeller.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.per_ad + ' ' + x.per_soyad,
                                                   Value = x.per_id.ToString()
                                               }).ToList();
            ViewBag.dropdeger2 = personel;



            return View();
        }
        [HttpPost]
        public ActionResult SatisEkle(tbl_satislar p)
        {
            var urun = db.tbl_urunler.Where(x => x.urun_id == p.tbl_urunler.urun_id).FirstOrDefault();
            var musteri = db.tbl_musteriler.Where(x => x.mus_id == p.tbl_musteriler.mus_id).FirstOrDefault();
            var perso = db.tbl_personeller.Where(x => x.per_id == p.tbl_personeller.per_id).FirstOrDefault();
            p.tbl_urunler = urun;
            p.tbl_musteriler = musteri;
            p.tbl_personeller = perso;
            p.tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.tbl_satislar.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}