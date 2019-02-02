using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Entity
{
    public class Season
    {
        public int Id { get; set; }
        public DateTime Year { get; set; }

        public ICollection<Coaching> Coaching { get; set; }
       
    }
}