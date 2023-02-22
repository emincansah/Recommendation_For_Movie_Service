using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFM.Data.Entity.EntityModel
{
    public class EmailActionEntity
    {
        public int Id { get; set; }
        public string email { get; set; }
        public int moiveId { get; set; } 
        public int status { get; set; }
    }
}
