using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCommerce.DataAccess.Repository.IRepository;
using BookCommerce.Model;

namespace BookCommerce.DataAccess.Repository
{
    public class MbulesaRepository:Repository<Mbulesa>,IMbulesaRepository
    {
        private readonly Konteksti _konteksti;

        public MbulesaRepository(Konteksti konteksti) : base(konteksti)
        {
            _konteksti = konteksti;
        }

        public void Update(Mbulesa mbulesa)
        {

            _konteksti.Update(mbulesa);
        }
    }
}
