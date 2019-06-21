using BandRegister.Models;
using Microsoft.AspNetCore.Mvc;
using BandRegister.Data;
using System.Linq;

namespace BandRegister.Controllers
{
    public class BandController : Controller
    {
        public IActionResult Index()
        {using(var db=new BandRegisterDbContext())
            {
                var bands = db.Bands.ToList();
                return View(bands);
            }
            
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
            
        }

        [HttpPost]
        public IActionResult Create(Band band)
        {
            using (var db = new BandRegisterDbContext())
            {
                db.Bands.Add(band);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
         
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new BandRegisterDbContext())
            {
                Band band = db.Bands.Find(id);
                return View(band);
            }
        }

        [HttpPost]
        public IActionResult Edit(Band band)
        {
            using (var db = new BandRegisterDbContext())
            {
                db.Bands.Update(band);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new BandRegisterDbContext())
            {
                Band band = db.Bands.Find(id);
                return View(band);
            }
        }

        [HttpPost]
        public IActionResult Delete(Band band)
        {
            using (var db = new BandRegisterDbContext())
            {
                db.Bands.Remove(band);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}