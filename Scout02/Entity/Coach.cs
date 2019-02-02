using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Entity
{
    public class Coach
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Coaching> Coaching { get; set; }
    }
}