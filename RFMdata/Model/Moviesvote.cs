using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RFM.Data.Model
{
    public class Moviesvote
    {
        [Key]
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int user_id { get; set; }
        public int vote { get; set; }
        public string note { get; set; }
    }
}
