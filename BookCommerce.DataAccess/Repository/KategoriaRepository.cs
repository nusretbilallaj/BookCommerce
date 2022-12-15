using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCommerce.DataAccess.Repository.IRepository;
using BookCommerce.Model;

namespace BookCommerce.DataAccess.Repository
{
    public class KategoriaRepository:Repository<Kategoria>,IKategoriaRepository
    {
        private readonly Konteksti _konteksti;

        public KategoriaRepository(Konteksti konteksti) : base(konteksti)
        {
            _konteksti = konteksti;
        }

        public void Update(Kategoria kategoria)
        {
            Kategoria kat = _konteksti.Kategorite.Find(kategoria.Id);
            if (kat!=null)
            {
                kat.Emri = kategoria.Emri;
            }
            _konteksti.Update(kategoria);
        }
    }
}
