using BookCommerce.DataAccess;
using BookCommerce.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookCommerce.Web.Areas.Admin.Controllers
{
    public class KategoriController : Controller
    {
        private readonly Konteksti _kon;

        public KategoriController(Konteksti kon)
        {
            _kon = kon;
        }
        public IActionResult Listo()
        {
            List<Kategoria> kategorite = _kon.Kategorite.ToList();
            return View(kategorite);
        }

        public IActionResult Krijo()
        {
            Kategoria kat = new Kategoria();
            return View(kat);
        }
        [HttpPost]
        public IActionResult Krijo(Kategoria kat)
        {
            if (ModelState.IsValid)
            {
                _kon.Kategorite.Add(kat);
                _kon.SaveChanges();
                TempData["suksesi"] = "U shtua me sukses";
                return RedirectToAction("Listo");
            }

            return View(kat);
        }

        public IActionResult Ndrysho(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Kategoria kat = _kon.Kategorite.Find(id);

            if (kat == null)
            {
                return NotFound();
            }
            return View(kat);
        }
        [HttpPost]
        public IActionResult Ndrysho(Kategoria kat)
        {
            if (ModelState.IsValid)
            {
                _kon.Kategorite.Update(kat);
                _kon.SaveChanges();
                TempData["suksesi"] = "U ndryshua me sukses";
                return RedirectToAction("Listo");
            }

            return View(kat);
        }
        public IActionResult Fshi(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Kategoria kat = _kon.Kategorite.Find(id);

            if (kat == null)
            {
                return NotFound();
            }
            return View(kat);
        }
        [HttpPost, ActionName("Fshi")]
        public IActionResult FshiP(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Kategoria katePrjDb = _kon.Kategorite.Find(id);
            if (katePrjDb == null)
            {
                return NotFound();
            }
            _kon.Kategorite.Remove(katePrjDb);
            _kon.SaveChanges();
            TempData["suksesi"] = "U fshi me sukses";
            return RedirectToAction("Listo");
        }
    }
}
