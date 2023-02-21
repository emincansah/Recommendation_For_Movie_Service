using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFM.Data.Entity.EntityModel
{
    public class MovieVoteEntity
    {
        public int Id { get; set; }
        public int user_id { get; set; }
        public double vote { get; set; }
        public double notes { get; set; }
    }
}
