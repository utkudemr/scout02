using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project.Entity
{
    public class UserPostPoint
    {
       
        public int Id { get; set; }
        public DateTime LastEditionTime { get; set; }
        public DateTime CreateTime { get; set; }
        [Key, Column(Order = 0)]
        public int UserId { get; set; }
        [Key, Column(Order = 1)]
        public int UserPostsId { get; set; }
        public bool IsActive { get; set; }
        public int FootballersId { get; set; }

        
        public UserPosts UserPosts { get; set; }
        public PhysicalAttributes PhysicalAttributes { get; set; }
    }
}