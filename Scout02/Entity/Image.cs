using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Entity
{
    public class Image
    {
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastEditionTime { get; set; }
        public string Images { get; set; }
        public int UserId { get; set; }

        public FootballerImage FootballerImages { get; set; }
    }
}