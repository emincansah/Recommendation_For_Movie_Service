using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace RFM.Entities.Conrete
{
    public class Moviesvote : BaseEntity, IEntity
    {
    
    
        [ForeignKey("MovieId")]
        public int MovieId { get; set; }
        public int user_id { get; set; }
        public int vote { get; set; }
        public string note { get; set; }
    }
}
