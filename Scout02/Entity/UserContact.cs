
using Scout02.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project.Entity
{
    public class UserContact
    {

        [ForeignKey("ApplicationUser")]
        [StringLength(int.MaxValue)]

        public string Id { get; set; }

        [StringLength(8)]
        [Column(TypeName = "char")]
        public string PrivacyId { get; set; }



        //public virtual UserAddresses UserAddresses { get; set; }
        public virtual ICollection<UserAddresses> UserAddresses { get; set; }
        public virtual ICollection<UserSocialAccounts> UserSocialAccounts { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

       

    }
}