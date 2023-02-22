using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace RFM.Entities.Conrete
{
    public class EmailAction : BaseEntity, IEntity
    {
    
      
        public string email { get; set; }
        public int moiveId { get; set; } 
        public int status { get; set; }
    }
}
