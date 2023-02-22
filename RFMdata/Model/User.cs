﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFM.Data.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

    }
}
