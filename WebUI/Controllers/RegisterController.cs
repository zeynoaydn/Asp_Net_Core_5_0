using Buusiness.Concrete;
using Buusiness.ValidationRules;
using DataAccess.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
	public class RegisterController : Controller
	{
		WriterManager wm=new WriterManager(new EfWriterRepository());
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(Writer p)
		{
			WriterValidate validationrules = new WriterValidate();
			ValidationResult result = validationrules.Validate(p);
			if(result.IsValid)
			{
				p.WriterStatus = true;
				p.WriterAbout = "deneme test";
				wm.TAdd(p);
				return RedirectToAction("Index", "Blog");
			}
			else
			{
				foreach(var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
		}
	}
}
