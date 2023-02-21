using RFM.Data.Entity.EntityModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFM.Data.Entity.ResponseModels
{
    public class MovieListResponse
    {
        public List<MoviesEntity> Movie  { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
    

    }
}
