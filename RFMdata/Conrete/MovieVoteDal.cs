using Core.DataAccess.EntityFramework;
using RFM.Data.Context;
using RFM.DataAccess.Interfaces;
using RFM.Entities.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFM.DataAccess.Conrete
{
    public class MovieVoteDal: EntityFrameworkRepository<Moviesvote, DataContext>, IMovieVoteDal
    {
    }
}
