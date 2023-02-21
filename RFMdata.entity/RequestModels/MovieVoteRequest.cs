using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFM.Data.Entity.RequestModels
{
    public class MovieVoteRequest
    {
        [Required(ErrorMessage = "MovieId is required")]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public int Vote { get; set; }    
        public string Note { get; set; }
    }
}
