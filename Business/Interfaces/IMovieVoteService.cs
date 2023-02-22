using RFM.Data.Entity.RequestModels;
using RFM.Entities.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IMovieVoteService
    {
        Task<bool> PostVote(MovieVoteRequest request);
       
    }
}
