using Buusiness.Concrete;
using DataAccess.EntityFramework;
using DataAccess.Migrations;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class NewsLetterController : Controller
	{
		NewsLetterManager nm = new NewsLetterManager(new EfNewsLetterRepository());
		[HttpGet]
		public PartialViewResult SubsribeMail()
		{
			return PartialView();
		}
		[HttpPost]
		public IActionResult SubsribeMail(NewsLetter p)
		{
			p.MailStatus = true;
			nm.NewsLetterAdd(p);
			return PartialView();
		}
	}
}
