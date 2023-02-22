using Core.DataAccess;
using RFM.Entities.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFM.DataAccess.Interfaces
{
    public interface ILoginDal : IEntityRepository<User>
    {
    }
}
