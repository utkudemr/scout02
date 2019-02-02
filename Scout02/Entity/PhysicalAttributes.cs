using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Entity
{
    public class PhysicalAttributes
    {
        public int Id { get; set; }
        public float Pace { get; set; }
        public float Agility { get; set; }
        public float Stamina { get; set; }
        public float Jumping { get; set; }
        public float Balance { get; set; }

        public ICollection<UserPostPoint> UserPostPoints { get; set; }
    }
}