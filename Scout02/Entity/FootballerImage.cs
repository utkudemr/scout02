using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project.Entity
{
    public class FootballerImage
    {
       [ForeignKey("Footballer")]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PrivacyId { get; set; }
        public Footballer Footballer { get; set; }

        public ICollection<Image> Images { get; set; }

    }
}