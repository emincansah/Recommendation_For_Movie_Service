using RFM.Data.Entity.RequestModels;
using RFM.Data.Entity.ResponseModels;
using RFM.Entities.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IMovieService
    {
        Task<Movies> GetMovies(int id);
        Task<MovieListResponse> GetMoviesList(MovieListRequest request);
        Task<int> GetCount();
        Task<bool> Update(MovieVoteRequest request);
        Task<bool> PostMovie(Movies movie);
        



    }
}
