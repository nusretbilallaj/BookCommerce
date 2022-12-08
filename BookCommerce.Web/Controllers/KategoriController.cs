using BookCommerce.DataAccess;
using BookCommerce.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookCommerce.Web.Controllers
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
           List<Kategoria> kategorite= _kon.Kategorite.ToList();
            return View(kategorite);
        }
    }
}
