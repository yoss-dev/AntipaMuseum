﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntipaMuseum.Core.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public Visitor Visitor { get; set; }
        public int VisitorId { get; set; }
        public DateTimeOffset VisitDate { get; set; }
    }
}
