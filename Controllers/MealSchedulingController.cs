using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Socials.Contracts;
using Socials.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static Socials.Common.Enums;

namespace Socials.Controllers
{
	public class MealSchedulingController : Controller
	{
		private readonly IFoodScheduling _foodScheduling;
        public MealSchedulingController(IFoodScheduling foodScheduling)
		{
			_foodScheduling = foodScheduling;
		}

		public IActionResult Index()
		{
			return View();
		}

        public async Task<IActionResult> GetScheduledFood(string frequency)
        {
            MealFrequencyEnum frequencyEnum;
			var freq = Enum.TryParse<MealFrequencyEnum>(frequency, true, out frequencyEnum);
            var result = _foodScheduling.GetScheduledFood((int)frequencyEnum, "Pat").Result;
            return Ok(result);
        }
    }
}
