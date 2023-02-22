using RFM.Entities.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFM.Data.Entity.ResponseModels
{
    public class MovieListResponse
    {
        List<MoviesEntity> moviesEntity=new List<MoviesEntity>();
        public int total_results { get; set; }
        public int total_pages { get; set; }
    

    }
}
