using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunTakipSistemiMvc5.Models.Entitiy;
namespace UrunTakipSistemiMvc5.Controllers
{
    public class AdminController : Controller
    {
        DbMvcStokEntities1 db = new DbMvcStokEntities1 ();  
        // GET: Admin
        public ActionResult Index()
        {
            var admin = db.tbl_adminler.ToList();
            return View(admin);
        }
        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminEkle(tbl_adminler p)
        {
            db.tbl_adminler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}