using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sube2.HelloMvc.Models;

namespace Sube2.HelloMvc.Controllers
{
    public class DersController : Controller
    {
        private readonly OkulDbContext _context;

        public DersController(OkulDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            using (var ctx = new OkulDbContext())
            {

                var lst = ctx.Dersler.ToList();
                return View(lst);
            }
        }
        [HttpGet]
        public IActionResult AddDers()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDers(Ders ders) 
        {
            if (ders !=null)
            {
                using (var ctx = new OkulDbContext())
                {
                    ctx.Dersler.Add(ders);
                    ctx.SaveChanges();
                }
                

                //// Öğrenciye ders ekleme işlemi
                //using(var ctx = new OkulDbContext())
                //{
                //    var ogrenciDers = new OgrenciDers { Ogrenciid = ogrenciId, Dersid = ders.Dersid };
                //    ctx.OgrenciDersler.Add(ogrenciDers);
                //    ctx.SaveChanges();
                //}
                
                //_context.OgrenciDersler.Add(ogrenciDers);
                //_context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(ders);
        }

        [HttpGet]
        public IActionResult EditDers(int dersid)
        {
            using(var ctx = new OkulDbContext()) 
            {
                var ders = ctx.Dersler.Find(dersid);
                if(ders==null)
                {
                    return NotFound();
                }
                return View(ders);
            }
        }
        [HttpPost]
        public IActionResult EditDers(Ders ders)
        {
            if (ders != null)
            {
                using (var ctx = new OkulDbContext())
                {
                    ctx.Entry(ders).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteDers(int dersid)
        {
            using (var ctx = new OkulDbContext())
            {
                ctx.Dersler.Remove(ctx.Dersler.Find(dersid));
                ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
