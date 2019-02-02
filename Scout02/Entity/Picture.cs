using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Scout02.Entity
{
    public class Picture
    {
        public int Id { get; set; }
        public DateTime? CreateTime { get; set; }

        public string Title { get; set; }

        [Column(TypeName = "varchar(MAX)")]
        public string ImagePath { get; set; }

        [StringLength(int.MaxValue)]

        public string ImagesId { get; set; }
        [ForeignKey("ImagesId")]
        public UserImages UserImages { get; set; }
    }
}