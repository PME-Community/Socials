using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static Socials.Models.GameOfThrone;
using System.Net.Http;
using System.Threading.Tasks;
using Socials.Models;

namespace Socials.Controllers
{
	public class BoredomActivitiesController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

        public async Task<IActionResult> RandomActivityJson()
        {
            var quoteDetails = new BoredomActivity();

            using (var client = new HttpClient())
            {
                string apiUrl = "https://www.boredapi.com/api/activity/";

                HttpResponseMessage response = client.GetAsync(apiUrl).Result;
                if (response.IsSuccessStatusCode)
                {
                    quoteDetails = JsonConvert.DeserializeObject<BoredomActivity>(response.Content.ReadAsStringAsync().Result);
                }
            }

            var data = quoteDetails;

            return Ok(data);
        }

        public async Task<IActionResult> RandomActivityByType(string activityType = "education")
        {
            var quoteDetails = new BoredomActivity();

            using (var client = new HttpClient())
            {
                string apiUrl = "https://www.boredapi.com/api/activity/?type=";

                HttpResponseMessage response = client.GetAsync(apiUrl + activityType).Result;
                if (response.IsSuccessStatusCode)
                {
                    quoteDetails = JsonConvert.DeserializeObject<BoredomActivity>(response.Content.ReadAsStringAsync().Result);
                }
            }

            var result = quoteDetails;

            return Ok(result);
        }
    }
}
