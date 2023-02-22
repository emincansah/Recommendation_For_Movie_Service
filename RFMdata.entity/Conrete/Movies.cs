using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFM.Entities.Conrete
{
    public class Movies: BaseEntity,IEntity
    {
   
        public string original_language { get; set; }
        public string title { get; set; }
        public string overview { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }
        public IList<Moviesvote> Votes { get; set; }
    }
}
