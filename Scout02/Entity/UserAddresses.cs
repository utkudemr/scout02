
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project.Entity
{
    public class UserAddresses
    {
       [Key]
        public int Id { get; set; }
        public string UserAddress { get; set; }
        public string City { get; set; }
        public DateTime? LastEditionTime { get; set; }
        public string Title { get; set; }



        [StringLength(int.MaxValue)]
        
        public string UserContactId { get; set; }
        [ForeignKey("UserContactId")]
        public UserContact UserContact { get; set; }

        
       

       
    }
}