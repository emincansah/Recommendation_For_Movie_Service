using Business.Interfaces;
using RFM.Data.Entity.RequestModels;
using RFM.Data.Entity.ResponseModels;
using RFM.DataAccess.Interfaces;
using RFM.Entities.Conrete;
using RFM.Helper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RFM.Helper.Enums.Enums;

namespace Business.Manager
{
    public class RecommendationManager:IRecommendationService
    {
        private readonly IRecommendationDal _recommendationdal;

        public RecommendationManager(IRecommendationDal recommendationdal)
        {
            _recommendationdal = recommendationdal;
        }
        
        public async Task<bool> PostMovieRecommendation(RecommendationRequest request)
        {
            EmailAction emailaction = new EmailAction();
            emailaction.email = request.Email;
            emailaction.moiveId = request.MovieId;
            emailaction.status = EmailStatus.Draft.GetIntValue();
            return await _recommendationdal.Add(emailaction);
        }
        public async Task<bool> PostMovieRecommendationUpdate(EmailAction action)
        {
            return await _recommendationdal.Update(action);
        }
        public async Task<EmailAction> GetMovieRecommendation(RecommendationRequest request)
        {
          
            return await _recommendationdal.Get(x=>x.status == EmailStatus.Draft.GetIntValue() && x.moiveId==request.MovieId && x.email==request.Email);
        }

    }
}
