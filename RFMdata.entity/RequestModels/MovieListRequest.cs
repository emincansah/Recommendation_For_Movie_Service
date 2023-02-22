using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFM.Data.Entity.ResponseModels
{
    public class MovieListRequest
    {
        [Required(ErrorMessage = "PageNumber is required")]
        public int PageNumber { get; set; }

    }
}
