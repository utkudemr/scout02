using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Entity
{
    public class Leauge
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Team> Team { get; set; }
        public Country Country { get; set; }
    }
}