using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project.Entity
{
    public class UserPostsLike
    {
      
        public int Id { get; set; }
        public DateTime LastEditionTime { get; set; }
        public DateTime CreateTime { get; set; }
        [Key, Column(Order = 0)]
        public int UserId { get; set; }
        [Key, Column(Order = 1)]
        public int UserPostsId { get; set; }
        public bool IsClicked { get; set; }

        public UserPosts UserPosts { get; set; }
    }
}