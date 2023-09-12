using Buusiness.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Blog
{
    public class BlogLastDashboard:ViewComponent
    {
        BlogManager cm = new BlogManager(new EfBlogRepository());
        public IViewComponentResult Invoke()
        {
            var values = cm.GetBlogListWithCategory();
            return View(values);
        }
    }
}
