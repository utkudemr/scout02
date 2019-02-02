using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Entity
{
    public class Squad
    {
        public int Id { get; set; }
        public int KitNumber { get; set; }

        public Footballer Footballer { get; set; }
        public Team Team { get; set; }
    }
}