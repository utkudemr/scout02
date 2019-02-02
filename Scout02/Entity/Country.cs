using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Entity
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Flag { get; set; }

        public ICollection<Leauge> Leauge { get; set; }
    }
}