using Socials.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static Socials.Common.Enums;
using System;

namespace Socials.Models
{
	public class FoodScheduling
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string Breakfast { get; set; }
        [Required]
        public string Launch { get; set; }
        [Required]
        public string Dinner { get; set; }
        [Required]
        public MealFrequencyEnum SelectedFrequency { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string BatchNumber { get; set; }
        [Required]
        public DateTime MealDate { get; set; }
    }
}
