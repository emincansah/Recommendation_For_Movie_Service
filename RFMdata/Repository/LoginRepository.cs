using RFM.Data.Context;
using RFM.Data.Entity.EntityModel;
using RFM.Data.Entity.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RFM.Helper.Enums.Enums;

namespace RFM.Data.Repository
{
    public class LoginRepository
    {
        public static LoginResults LoginRepo(LoginRequest request)
        {
            

            try
            {
               
                if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                    return LoginResults.EmptyUserOrNamePass;

                using (var db = new DataContext())
                {
                    var users = db.Users.Where(x => x.username == request.Username && x.password== request.Password).FirstOrDefault();


                    if (users == null)
                        return LoginResults.InvalidLogin;
                    else
                    {
                        
                        return LoginResults.Success;
                      
                    }
                   
                }


            }
            catch (Exception ex) {
                return LoginResults.DbError;
            }
        }
    }
}