using RFM.Data.Entity.RequestModels;

namespace Recommendation_For_Movie_Service.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
