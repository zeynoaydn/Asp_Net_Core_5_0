using Buusiness.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Blog
{
	public class BlogLast3Post:ViewComponent
	{
		BlogManager cm = new BlogManager(new EfBlogRepository());
		public IViewComponentResult Invoke()
		{
			var values = cm.GetLast3Blog();
			return View(values);
		}
	}
}
