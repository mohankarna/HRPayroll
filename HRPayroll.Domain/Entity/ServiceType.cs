﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPayroll.Domain
{
   public class ServiceType
    {
        public int Id { get; set; }
        [Required]

        public String ServiceName { get; set; }
    }
}
