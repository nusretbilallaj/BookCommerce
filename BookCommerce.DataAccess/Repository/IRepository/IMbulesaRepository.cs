using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCommerce.Model;

namespace BookCommerce.DataAccess.Repository.IRepository
{
    public interface IMbulesaRepository:IRepository<Mbulesa>
    {
        void Update(Mbulesa mbulesa);
    }
}
