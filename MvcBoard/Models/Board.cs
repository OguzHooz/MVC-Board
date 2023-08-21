﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcBoard.Models
{
    public class Board
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-z\s]*$")]
        public string? Name { get; set; }
        
        [Display(Name = "Length(feet)")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Length { get; set; }

        [Display(Name = "Width(inches)")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Width { get; set; }

        [Display(Name = "Thickness(inches)")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Thickness { get; set; }

        [Display(Name = "Volume(L)")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Volume { get; set; }

        [Required]
        [StringLength (100, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-z\s]*$")]
        public string? Type { get; set; }

        [Display(Name = "Price(€)")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-z\s]*$")]
        public string? Equipment { get; set; }
    }
}