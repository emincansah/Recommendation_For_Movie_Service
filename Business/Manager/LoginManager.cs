using Business.Interfaces;
using RFM.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Manager
{

    public class LoginManager : ILoginService
    {
        private readonly ILoginDal _logindal;

        public LoginManager(ILoginDal logindal)
        {
            _logindal = logindal;
        }

        public Task<bool> Logins(string username, string password)
        {
            throw new NotImplementedException();
        }

    }

}
