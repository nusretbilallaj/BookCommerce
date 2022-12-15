using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCommerce.DataAccess.Repository.IRepository;

namespace BookCommerce.DataAccess.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly Konteksti _konteksti;

        public UnitOfWork(Konteksti konteksti)
        {
            _konteksti = konteksti;
            Kategoria = new KategoriaRepository(_konteksti);
            Mbulesa = new MbulesaRepository(_konteksti);
        }
        public IKategoriaRepository Kategoria { get; }
        public IMbulesaRepository Mbulesa { get; }

        public void Save()
        {
            _konteksti.SaveChanges();
        }
    }
}
