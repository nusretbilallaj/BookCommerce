using BookCommerce.DataAccess;
using BookCommerce.DataAccess.Repository.IRepository;
using BookCommerce.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookCommerce.Web.Areas.Admin.Controllers
{
    public class MbulesaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        public MbulesaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Listo()
        {
            List<Mbulesa> mbulesat = _unitOfWork.Mbulesa.GetAll().ToList();
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
                _unitOfWork.Mbulesa.Add(mbulesa);
                _unitOfWork.Save();
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

            Mbulesa mbulesa = _unitOfWork.Mbulesa.GetFirstOrDefault(x=>x.Id==id);

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
                _unitOfWork.Mbulesa.Update(mbulesa);
                _unitOfWork.Save();
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

            Mbulesa mbulesa = _unitOfWork.Mbulesa.GetFirstOrDefault(x=>x.Id==id);

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
                = _unitOfWork.Mbulesa.GetFirstOrDefault(x=>x.Id==id);
            if (mbulesaPrejDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Mbulesa.Remove(mbulesaPrejDb);
            _unitOfWork.Save();
            TempData["suksesi"] = "U fshi me sukses";
            return RedirectToAction("Listo");
        }
    }
}
