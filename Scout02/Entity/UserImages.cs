using Scout02.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Scout02.Entity
{
    public class UserImages
    {
        [ForeignKey("ApplicationUser")]
        [StringLength(int.MaxValue)]
        public string Id { get; set; }
        public string PrivacyId { get; set; }

       

        public virtual ICollection<Picture> Pictures { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}