using RFM.Entities.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFM.Data.Entity.ResponseModels
{
    public class MovieDetailResponse
    {
        public int Id { get; set; }
        public string original_language { get; set; }
        public string title { get; set; }
        public string overview { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }

    }
}
