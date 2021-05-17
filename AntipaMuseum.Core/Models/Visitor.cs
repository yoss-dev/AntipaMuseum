using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntipaMuseum.Core.Models
{
    public class Visitor
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public bool IsChild { get; set; }

        public ICollection<Visit> Visits { get; set; }

    }
}
