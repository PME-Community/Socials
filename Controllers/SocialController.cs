using Microsoft.AspNetCore.Mvc;

namespace Socials.Controllers
{
	public class SocialController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
    }
}
