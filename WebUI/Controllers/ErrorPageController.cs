using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
	public class ErrorPageController : Controller
	{
		public IActionResult Error1(int code)
		{
			return View();
		}
	}
}
