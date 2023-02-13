using System;
using System.ComponentModel.DataAnnotations;

namespace Socials.Models
{
	public class FoodSchedulingViewModel
	{
        public string Breakfast { get; set; }
        public string Launch { get; set; }
        public string Dinner { get; set; }
        public string MealDate { get; set; }
    }
}
