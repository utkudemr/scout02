
using Scout02.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project.Entity
{
    public class UserPosts
    {
        
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastEditionTime { get; set; }
        public int ViewCount { get; set; }
        public string Comment { get; set; }
        public int MyProperty { get; set; }
        public int PrivacyId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public Footballer Footballer { get; set; }
        public ICollection<UserPostsLike> UserPostsLike { get; set; }
        public ICollection<UserPostPoint> UserPostPoints { get; set; }
    }
}