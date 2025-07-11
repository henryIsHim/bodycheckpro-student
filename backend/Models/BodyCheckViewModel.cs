using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BodyCheckWebAPI.Models
{
    public class BodyCheckViewModel
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("StudentId")]
        [DisplayName("Student Id")]
        public string? StudentId { get; set; } = "-";
        [Column("Firstname")]
        [DisplayName("First Name")]
        public required string Firstname { get; set; } = "";
        [Column("Lastname")]
        [DisplayName("Last Name")]
        public required string Lastname { get; set; } = "";
        [Column("HeightCm")]
        [DisplayName("Height (Cm.)")]
        public float HeightCm { get; set; } = 0;
        [Column("WeightKg")]
        [DisplayName("Weight (Kg.)")]
        public float WeightKg { get; set; } = 0;
    }
}