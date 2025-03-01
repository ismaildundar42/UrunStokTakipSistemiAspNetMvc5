using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunTakipSistemiMvc5.Models.Entitiy;
namespace UrunTakipSistemiMvc5.Controllers
{
    public class UrunController : Controller
    {
        DbMvcStokEntities1 db = new DbMvcStokEntities1();
        // GET: Urun
        public ActionResult Index(string p)
        {
          //  var urunler = db.tbl_urunler.Where(x => x.urun_durum==true).ToList();
          var urunler = from x in db.tbl_urunler select x;
            if(!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(x => x.urun_ad.Contains(p) && x.urun_durum==true);
            }
            return View(urunler.ToList());
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> ktg = (from x in db.tbl_kategoriler.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.kategori_ad,
                                            Value = x.kategori_id.ToString()
                                        }).ToList();
            ViewBag.dropdeger = ktg;
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(tbl_urunler p)
        {
            var ktgr = db.tbl_kategoriler.Where(x=> x.kategori_id == p.tbl_kategoriler.kategori_id).FirstOrDefault();
            p.tbl_kategoriler = ktgr;
            p.urun_durum = true;
            db.tbl_urunler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            // Kategori listesini oluştur
            List<SelectListItem> kat = (from x in db.tbl_kategoriler.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.kategori_ad,
                                            Value = x.kategori_id.ToString()
                                        }).ToList();

            // Ürünü bul
            var urun = db.tbl_urunler.Find(id);
            ViewBag.dropdeger = kat;

            // Ürünün mevcut kategorisini seçili yapmak için
            ViewBag.SeciliKategori = urun.urun_kategori;

            return View("UrunGetir", urun);
        }

        [HttpGet]
        public ActionResult UrunGuncelle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UrunGuncelle(tbl_urunler p)
        {
            var urn = db.tbl_urunler.Find(p.urun_id);
            urn.urun_ad = p.urun_ad;
            urn.urun_marka = p.urun_marka;
            urn.urun_stok = p.urun_stok;
            urn.alis_fiyat = p.alis_fiyat;
            urn.satis_fiyat = p.satis_fiyat;
            urn.urun_kategori = p.urun_kategori;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var urunbul = db.tbl_urunler.Find(id);
            urunbul.urun_durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}