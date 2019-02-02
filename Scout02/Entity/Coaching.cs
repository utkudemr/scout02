using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Entity
{
    public class Coaching
    {
        public int Id { get; set; }
        public Team Team { get; set; }
        public Coach Coach { get; set; }
        public Season Season { get; set; }

    }
}