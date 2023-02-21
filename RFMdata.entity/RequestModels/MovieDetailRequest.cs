using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFM.Data.Entity.ResponseModels
{
    public class MovieDetailRequest
    {
        [Required(ErrorMessage = "MovieId is required")]
        public int MovieId { get; set; }

    }
}
