using Business.Interfaces;
using RFM.Data.Entity.RequestModels;
using RFM.DataAccess.Interfaces;
using RFM.Entities.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Manager
{
    public class MovieVoteManager : IMovieVoteService
    {
        private readonly IMovieVoteDal _moviesvotedal;

        public MovieVoteManager(IMovieVoteDal moviesvotedal)
        {
            _moviesvotedal = moviesvotedal;
        }
        public async Task<bool> PostVote(MovieVoteRequest request)
        {
            Moviesvote moviesvote = new Moviesvote();
            moviesvote.vote = request.Vote;
            moviesvote.note = request.Note;
            moviesvote.user_id = 1;
            moviesvote.MovieId = request.MovieId;
            return await _moviesvotedal.Add(moviesvote);


        }

        public async Task<List<Moviesvote>> GetVote(int id)
        {
            
            return await _moviesvotedal.GetAll(x=>x.Id==id);


        }

    }
}
