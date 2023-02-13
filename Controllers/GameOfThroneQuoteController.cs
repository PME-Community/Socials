using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System;
using static Socials.Models.GameOfThrone;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Socials.Controllers
{
    public class GameOfThroneQuoteController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> RandomQuoteJson()
        {
            var quoteDetails = new GotQuote();

            using (var client = new HttpClient())
            {
                string apiUrl = "https://api.gameofthronesquotes.xyz/v1/random";

                HttpResponseMessage response = client.GetAsync(apiUrl).Result;
                if (response.IsSuccessStatusCode)
                {
                    quoteDetails = JsonConvert.DeserializeObject<GotQuote>(response.Content.ReadAsStringAsync().Result);
                }
            }

            var data = new
            {
                model = quoteDetails
            };

            return Ok(data);
        }

        public async Task<IActionResult> RandomQuoteList()
        {
            var quoteDetails = new List<GotQuote>();

            try
            {
                using (var client = new HttpClient())
                {
                    string apiUrl = "https://api.gameofthronesquotes.xyz/v1/random/5";

                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        quoteDetails = JsonConvert.DeserializeObject<List<GotQuote>>(response.Content.ReadAsStringAsync().Result);
                    }
                }

                var data = quoteDetails.Select(x => x.sentence);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}
