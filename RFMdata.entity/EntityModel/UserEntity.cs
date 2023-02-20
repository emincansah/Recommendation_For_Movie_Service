using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RFM.Helper.Enums.Enums;

namespace RFM.Data.Entity.EntityModel
{
    public class UserEntity:BaseEntity
    {
       

        public string UserName { get; set; }
        public string password { get; set; }
        public Guid? AccessToken { get; set; }
        public LoginResults results { get; set; }   
    }
}
