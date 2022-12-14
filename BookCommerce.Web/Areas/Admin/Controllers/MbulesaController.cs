using BookCommerce.DataAccess;
using BookCommerce.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookCommerce.Web.Areas.Admin.Controllers
{
    public class MbulesaController : Controller
    {
        private readonly Konteksti _kon;

        public MbulesaController(Konteksti kon)
        {
            _kon = kon;
        }
        public IActionResult Listo()
        {
            List<Mbulesa> mbulesat = _kon.Mbulesat.ToList();
            return View(mbulesat);
        }

        public IActionResult Krijo()
        {
            Mbulesa mbul = new Mbulesa();
            return View(mbul);
        }
        [HttpPost]
        public IActionResult Krijo(Mbulesa mbulesa)
        {
            if (ModelState.IsValid)
            {
                _kon.Mbulesat.Add(mbulesa);
                _kon.SaveChanges();
                TempData["suksesi"] = "U shtua me sukses";
                return RedirectToAction("Listo");
            }

            return View(mbulesa);
        }

        public IActionResult Ndrysho(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Mbulesa mbulesa = _kon.Mbulesat.Find(id);

            if (mbulesa == null)
            {
                return NotFound();
            }
            return View(mbulesa);
        }
        [HttpPost]
        public IActionResult Ndrysho(Mbulesa mbulesa)
        {
            if (ModelState.IsValid)
            {
                _kon.Mbulesat.Update(mbulesa);
                _kon.SaveChanges();
                TempData["suksesi"] = "U ndryshua me sukses";
                return RedirectToAction("Listo");
            }

            return View(mbulesa);
        }
        public IActionResult Fshi(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Mbulesa mbulesa = _kon.Mbulesat.Find(id);

            if (mbulesa == null)
            {
                return NotFound();
            }
            return View(mbulesa);
        }
        [HttpPost, ActionName("Fshi")]
        public IActionResult FshiP(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Mbulesa mbulesaPrejDb
                = _kon.Mbulesat.Find(id);
            if (mbulesaPrejDb == null)
            {
                return NotFound();
            }
            _kon.Mbulesat.Remove(mbulesaPrejDb);
            _kon.SaveChanges();
            TempData["suksesi"] = "U fshi me sukses";
            return RedirectToAction("Listo");
        }
    }
}
