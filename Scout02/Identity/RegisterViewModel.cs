using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Scout02.Identity
{
    public class RegisterViewModel
    {

        [Required]
        [DisplayName("Adınız")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Soyadınız")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Kullanıcı Adı")]
        public string Username { get; set; }

        [Required]
        [DisplayName("Cinsiyet")]
        public bool Gender { get; set; }

        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImagePath { get; set; }

        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyy}", ApplyFormatInEditMode = true)]
        public DateTime? Birthday { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-posta")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} en az {2} karakter uzunluğunda olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Parolayı onaylayın")]
        [Compare("Password", ErrorMessage = "Parola ve onay parolası aynı değil.")]
        public string ConfirmPassword { get; set; }
    }
}