using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Entity
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TeamIcon { get; set; }

        public ICollection<Coaching> Coaching { get; set; }
        public Leauge Leauge { get; set; }

    }
}