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

        public async Task<bool> Logins(string username, string password)
        {
            try
            {
                var user =await _logindal.Get(x => x.username == username && x.password == password);
                if (user != null)
                    return true;
                else
                    return false;

            }
            catch (Exception)
            {

                return false; 
            }
           
        }

    }

}
