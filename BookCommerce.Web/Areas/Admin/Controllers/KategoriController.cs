using BookCommerce.DataAccess;
using BookCommerce.DataAccess.Repository.IRepository;
using BookCommerce.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookCommerce.Web.Areas.Admin.Controllers
{
    public class KategoriController : Controller
    {
     
        private readonly IUnitOfWork _unitOfWork;
        public KategoriController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Listo()
        {
            List<Kategoria> kategorite = _unitOfWork.Kategoria.GetAll().ToList();
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
                _unitOfWork.Kategoria.Add(kat);
                _unitOfWork.Save();
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

            Kategoria kat = _unitOfWork.Kategoria.GetFirstOrDefault(x=>x.Id==id);

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
                _unitOfWork.Kategoria.Update(kat);
                _unitOfWork.Save();
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

            Kategoria kat = _unitOfWork.Kategoria.GetFirstOrDefault(x=>x.Id==id);

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

            Kategoria katePrjDb = _unitOfWork.Kategoria.GetFirstOrDefault(x=>x.Id==id);
            if (katePrjDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Kategoria.Remove(katePrjDb);
            _unitOfWork.Save();
            TempData["suksesi"] = "U fshi me sukses";
            return RedirectToAction("Listo");
        }
    }
}
