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
using RFM.Data.Entity.RequestModels;
using System.Drawing.Printing;

namespace Business.Manager
{
    public class MovieManager : IMovieService
    {
        private readonly IMovieDal _moviesdal;
        private readonly IMovieVoteDal _moviesvotedal;
        public MovieManager( IMovieDal moviesdal, IMovieVoteDal moviesvotedal)
        {
            _moviesdal = moviesdal;
            _moviesvotedal = moviesvotedal;
        }
        public async Task<bool> PostMovie(Movies movie)
        {
            Movies movies = new Movies();
            movies.title = movie.title;
            movies.overview = movie.overview;
            movies.vote_average = 0;
            movies.vote_count = 0;
            movies.original_language = movie.original_language;           
            return await _moviesdal.Add(movies);
        }

        public async Task<bool> Update(MovieVoteRequest request)
        {
            var movie = await _moviesdal.Get(x=>x.Id==request.MovieId);
            movie.vote_count++;
            double totalvote = movie.vote_average * movie.vote_count;
            totalvote += request.Vote;
            movie.vote_average = totalvote/movie.vote_count;

            return await _moviesdal.Update(movie);
        }

        public async Task<int> GetCount()
        {
          return await _moviesdal.Count();
        }

        public async Task<Movies> GetMovies( int id)
        {
            Movies movie = await _moviesdal.Get(x => x.Id == id);
            var votelis = await _moviesvotedal.GetAll(x => x.MovieId == id);
            movie.Votes = new List<Moviesvote> { };
            foreach (var votel in votelis)
            {
                movie.Votes.Add(votel);
            }
            return movie;
        }
        public async Task<MovieListResponse> GetMoviesList(MovieListRequest request)
        {
            MovieListResponse movieListResponse= new MovieListResponse();
            var count = await _moviesdal.Count();
            int pagecount = (count / 100) + (count % 100 > 0 ? 1 : 0);
            int listcount = request.PageNumber * 100;
            var movielist = await _moviesdal.GetAll();
            List<Movies> result = new List<Movies>();
            if (request.PageNumber == 1)
             result = movielist.Take(100).ToList();
           else
             result = movielist.Take(100).Skip((request.PageNumber - 1) * pagecount).ToList();


            foreach (var movieitem in movielist)
            {
                MoviesEntity movie = new MoviesEntity();
                movie.Id = movieitem.Id;
                movie.overview = movieitem.overview;
                movie.vote_average = movieitem.vote_average;
                movie.title = movieitem.title;
                movie.vote_count = movieitem.vote_count;
                movieListResponse.Movies =new List<MoviesEntity> {  };
                movieListResponse.Movies.Add(movie);
            }
            movieListResponse.total_pages = pagecount;
            movieListResponse.total_results = movielist.Count;
            return movieListResponse;
        }
       
      


    } 
}
