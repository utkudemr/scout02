using Project.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Scout02.Models
{
    public class AllUserViewModel
    {
        [ForeignKey("ApplicationUser")]
        [StringLength(int.MaxValue)]
        public string UserId { get; set; }
        public string ApplicationUserId { get; set; }
        public string RoleId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime? RegisterDate { get; set; }
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyy}", ApplyFormatInEditMode = true)]
        public DateTime? Birthday { get; set; }
        public int Age()
        {
            DateTime dt;
            dt = Birthday.Value;
            var now = DateTime.Now.Year;
            var age = dt.Year;
            var result = now - age;
            return result;

        }
        public bool Gender { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastEditionTime { get; set; }
        public string UserName { get; set; }
        public string UserContactId { get; set; }
        [Display(Name = "Resim")]
        public string ImagePath { get; set; }
        public string RoleName { get; set; }
        public int AddressId { get; set; }
        public string UserAddress { get; set; }
        public string City { get; set; }
        public string Title { get; set; }
        

        public UserSocialAccounts UserSocialAccounts { get; set; }
    }
}