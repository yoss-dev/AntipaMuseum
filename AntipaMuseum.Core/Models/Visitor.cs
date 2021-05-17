using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntipaMuseum.Core.Models
{
    public class Visitor
    {
        public int Id { get; set; }

        [Required]
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public bool IsChild { get => Age < 12; }

        public ICollection<Visit> Visits { get; set; }

    }
}
