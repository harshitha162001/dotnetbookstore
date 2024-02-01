﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BulkyWebRezorproject.Models
{
    public class Category
    {
       
            [Key]
            public int Id { get; set; }
            [Required]
            [DisplayName("CategoryName")]
            [MaxLength(30)]
            public string Name { get; set; }
            [DisplayName("Display Order")]
            [Range(1, 100, ErrorMessage = "Display order must be between 1 - 100")]
            public int DisplayOrder { get; set; }
        
    }
}
