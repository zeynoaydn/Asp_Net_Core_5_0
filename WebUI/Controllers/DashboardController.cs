using DataAccess.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebUI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            Context context = new Context();

            var username = User.Identity.Name;
            var usermail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerid=context.Writers.Where(x => x.WriterMail==usermail).Select(y=>y.WriterID).FirstOrDefault();

            ViewBag.v1=context.Blogs.Count().ToString();
            ViewBag.v1 = context.Blogs.Where(x => x.WriterID == writerid).Count();
            ViewBag.v3 = context.Categories.Count();
            return View();
        }
    }
}
