using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project.Entity
{
   
    public class Footballer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }

        public FootballerImage FootballerImage { get; set; }
        public ICollection<Squad> Squad { get; set; }
        public ICollection<UserPosts> UserPosts { get; set; }


    }
}