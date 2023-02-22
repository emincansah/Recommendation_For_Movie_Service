using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFM.Entities.Conrete
{
    public class User : BaseEntity, IEntity
    {
    
        public string username { get; set; }
        public string password { get; set; }

    }
}
