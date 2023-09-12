using Buusiness.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [AllowAnonymous]

    public class AboutController : Controller
	{
		AboutManager ma = new AboutManager(new EfAboutRepository());
		public IActionResult Index()
		{
			var values = ma.GetList();

			return View(values);
		}
		public PartialViewResult SocialMediaAbout()
		{
			return PartialView();
		}
	}
}
