using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sube2.HelloMvc.Models;

namespace Sube2.HelloMvc.Controllers
{
    public class OgrenciDersController : Controller
    {
        private readonly OkulDbContext _context;

        public OgrenciDersController(OkulDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {                
            return View();
            
        }
        [HttpGet]
        public IActionResult TakenDers(int ogrenciid)
        {
            using(var ctx = new OkulDbContext())
            {
                var lst = ctx.OgrenciDersler
                    .Include(od => od.Ders)
                    .Include(od => od.Ogrenci)
                    .Where(od => od.Ogrenciid == ogrenciid).ToList();
                ViewBag.OgrenciId = ogrenciid;
                return View(lst);
            }
            
        }
        [HttpGet]
        public IActionResult AddOgrDers(int ogrenciid)
        {
            using(var ctx = new OkulDbContext())
            {
                var lst = ctx.OgrenciDersler
                    .Where(od => od.Ogrenciid == ogrenciid)         
                    .Select(od => od.Dersid)
                    .ToList();

                var lst2 = ctx.Dersler.Where(d => !lst.Contains(d.Dersid)).ToList();

                ViewData["OgrenciId"] = ogrenciid;
                return View(lst2);
            }
        }
        [HttpPost]
        public IActionResult AddOgrDers(int ogrenciid,int dersid)
        {
            var ogrenciders = new OgrenciDers
            {
                Ogrenciid = ogrenciid,
                Dersid = dersid
            };
                using (var ctx = new OkulDbContext())
                {
                    ctx.OgrenciDersler.Add(ogrenciders);
                    ctx.SaveChanges();
                }
            
            return RedirectToAction("TakenDers",new { Ogrenciid = ogrenciid });
        }
    }
}
