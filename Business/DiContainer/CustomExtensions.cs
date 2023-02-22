
using Business.Interfaces;
using Business.Manager;

using Microsoft.Extensions.DependencyInjection;
using RFM.DataAccess.Conrete;
using RFM.DataAccess.Interfaces;

namespace Business.DiContainer
{
    public static class CustomExtensions
    {
        public static void AddContainerWithDependencies(this IServiceCollection services)
        {
            // Business
            services.AddScoped<ILoginService, LoginManager>();
            services.AddScoped<IMovieService, MovieManager>();
            services.AddScoped<IMovieVoteService, MovieVoteManager>();
          

            // DataAccess
            services.AddScoped<ILoginDal, LoginDal>();
            services.AddScoped<IMovieDal, MoviesDal>();
            services.AddScoped<IMovieVoteDal, MovieVoteDal>();

        }
    }
}
