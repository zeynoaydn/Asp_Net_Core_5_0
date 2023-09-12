using Buusiness.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Blog
{
	public class WriterLastBlog:ViewComponent
	{
		BlogManager cm = new BlogManager(new EfBlogRepository());
		public IViewComponentResult Invoke()
		{
			var values = cm.GetBlogListByWriter(1);
			return View(values);
		}
	}
}
