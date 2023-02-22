using Business.Interfaces;
using RFM.DataAccess.Interfaces;
using RFM.DataAccess.Conrete;
using RFM.Entities.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFM.Data.Entity.ResponseModels;

namespace Business.Manager
{
    public class MovieManager : IMovieService
    {
        private readonly IMovieDal _moviesdal;

        public MovieManager( IMovieDal moviesdal)
        {
            _moviesdal = moviesdal;
        }      
        public Task<bool> Add(Movies movie)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetCount()
        {
          return await _moviesdal.Count();
        }

        public async Task<Movies> GetMovies( int id)
        {
            return await _moviesdal.Get(x=> x.Id == id);
        }
        public async Task<MovieListResponse> GetMoviesList(MovieListRequest request)
        {
            MovieListResponse movieListResponse= new MovieListResponse();
            var count = await _moviesdal.Count();
            int pagecount = count / 100;
            var movielist=  await _moviesdal.GetAll(pagecount);
            movieListResponse.total_pages = pagecount;
            movieListResponse.total_results = movielist.Count;
            return movieListResponse;
        }


    } 
}
