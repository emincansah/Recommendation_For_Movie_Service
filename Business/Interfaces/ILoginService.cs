using RFM.Data.Entity.ResponseModels;
using RFM.Entities.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ILoginService 
    {
        Task<bool> Logins(string username, string password);
       

    }
}
