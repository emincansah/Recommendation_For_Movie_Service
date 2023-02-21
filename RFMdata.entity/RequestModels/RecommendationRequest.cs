using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFM.Data.Entity.ResponseModels
{
    public class RecommendationRequest
    {
        [Required(ErrorMessage = "MovieId is required")]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
       
    }
}
