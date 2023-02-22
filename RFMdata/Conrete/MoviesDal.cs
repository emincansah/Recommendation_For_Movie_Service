using Core.DataAccess.EntityFramework;
using RFM.Entities.Conrete;
using RFM.Data.Context;
using RFM.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFM.DataAccess.Conrete
{
    public class MoviesDal : EntityFrameworkRepository<Movies, DataContext>, IMovieDal
    {
    }
}
