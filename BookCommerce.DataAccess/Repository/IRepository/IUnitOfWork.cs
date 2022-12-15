using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCommerce.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IKategoriaRepository Kategoria { get; }
        IMbulesaRepository Mbulesa { get; }
        void Save();
    }
}
