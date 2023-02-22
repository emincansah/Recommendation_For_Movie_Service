﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RFM.Data.Model
{
    public class EmailAction
    {
        [Key]
        public int Id { get; set; }
        public string email { get; set; }
        public int moiveId { get; set; } 
        public int status { get; set; }
    }
}
