﻿using RFM.Data.Context;
using RFM.Data.Entity.EntityModel;
using RFM.Data.Entity.RequestModels;
using RFM.Data.Entity.ResponseModels;
using RFM.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFM.Data.Repository
{
    public class MovieRepository
    {
        public static MovieListResponse GetMovieList(MovieListRequest request)
        {
            try
            {        
                using (var db = new DataContext())
                {
                    var totalmoviescount = db.Movies.AsQueryable().Count();
                    int pagecount = (totalmoviescount % request.MovieCount == 0 ? totalmoviescount % request.MovieCount : (totalmoviescount % request.MovieCount)+1);
                    int movielistcount = totalmoviescount / pagecount;
                    int skipcount = 1;
                    if (request.PageNumber != 1 )
                        skipcount = (request.PageNumber -1) * movielistcount;
                    
                    List<Movies> movies = db.Movies.Take(movielistcount).Skip(skipcount).ToList();

                     return DatatoEntityList(movies,totalmoviescount,pagecount);
                   

                }
            }
            catch (Exception ex)
            {
                MovieListResponse movieListResponse = new MovieListResponse();
                return movieListResponse;
            }
        }
        public static MovieDetailResponse GetMovieDetail(MovieDetailRequest request)
        {
            try
            {
                MovieDetailResponse movieDetailResponse = new MovieDetailResponse();
                using (var db = new DataContext())
                {
                    
                    Movies movies = db.Movies.Where(x=>x.Id == request.MovieId).FirstOrDefault();
                    List<Moviesvote> votes = db.Moviesvote.Where(x => x.MovieId == movies.Id).ToList();
                    if (movies != null)
                        return DatatoEntity(movies, votes);
                    else
                        return movieDetailResponse;

                }
            }
            catch (Exception ex)
            {
                MovieDetailResponse movieDetailResponse = new MovieDetailResponse();
                return movieDetailResponse;
            }
        }
        public static MovieDetailResponse DatatoEntity(Movies movie, List<Moviesvote> votes)
        {
            MovieDetailResponse movieDetailResponse = new MovieDetailResponse();
                List<MovieVoteEntity> votelist = new List<MovieVoteEntity>();

            movieDetailResponse.title = movie.title;
            movieDetailResponse.overview = movie.overview;
            movieDetailResponse.vote_average = movie.vote_average;
            movieDetailResponse.vote_count = movie.vote_count;
            movieDetailResponse.original_language = movie.original_language;
            movieDetailResponse.Id = movie.Id;

            MovieVoteEntity movievote = new MovieVoteEntity();  
            foreach (var vote in votes)
            {
                movievote.vote = vote.vote;
                movievote.notes = vote.note;
                movievote.Id = vote.Id;
                movievote.user_id = vote.user_id;
                votelist.Add(movievote);
            }

            movieDetailResponse.user_votes = votelist;
            return movieDetailResponse;
        }
        public static MovieListResponse DatatoEntityList(List<Movies> MovieList ,int totalcount,int pagecount )
        {
            MovieListResponse movieListResponse = new MovieListResponse();
            List<MoviesEntity> moviesEntities = new List<MoviesEntity>();   

            foreach (var movie in MovieList)
            {
                MoviesEntity movies = new MoviesEntity();
                movies.title = movie.title;
                movies.overview = movie.overview;
                movies.vote_average = movie.vote_average;
                movies.vote_count = movie.vote_count;
                movies.original_language = movie.original_language;
                movies.Id = movie.Id;
                moviesEntities.Add(movies);

            }
            movieListResponse.Movie = moviesEntities;
            movieListResponse.total_pages= pagecount;
            movieListResponse.total_results= totalcount;

            return movieListResponse;
        }
    }
}
