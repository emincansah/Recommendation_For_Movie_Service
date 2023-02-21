using RFM.Data.Context;
using RFM.Data.Entity.RequestModels;
using RFM.Data.Entity.ResponseModels;
using RFM.Data.Model;
using RFM.Helper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RFM.Helper.Enums.Enums;

namespace RFM.Data.Repository
{
    public class RecommendationRepository
    {
        public static RecommendationResponse PostRecommendation(RecommendationRequest request)
        {
            try
            {
                RecommendationResponse recommendationResponse = new RecommendationResponse();
                using (var db = new DataContext())
                {

                    Movies movies = db.Movies.Where(x => x.Id == request.MovieId).FirstOrDefault();

                    if (movies == null)
                        recommendationResponse.RecommendationResult = RecommendationResult.InvalidMovie;
                    else
                        recommendationResponse.RecommendationResult = EmailAction(movies, db, request);

                    return recommendationResponse;

                }
            }
            catch (Exception ex)
            {
                RecommendationResponse recommendationResponse = new RecommendationResponse();
                recommendationResponse.RecommendationResult = RecommendationResult.DbError;
                return recommendationResponse;
            }
        }
        public static RecommendationResult EmailAction(Movies movie, DataContext db, RecommendationRequest recommendation)
        {
            try
            {
                EmailAction newemailAction = new EmailAction();
                newemailAction.email=recommendation.Email;
                newemailAction.status = EmailStatus.Draft.GetIntValue();
                newemailAction.moiveId = movie.Id;
                db.EmailAction.Add(newemailAction);
                db.SaveChanges();

                return RecommendationResult.Success;
            }
            catch (Exception)
            {

                return RecommendationResult.DbError;
            }

        }
    }
}
