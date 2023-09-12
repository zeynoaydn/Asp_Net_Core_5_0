using Buusiness.Concrete;
using Buusiness.ValidationRules;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Controllers
{
	//[Authorize]
	public class WriterController : Controller
	{
		WriterManager wm = new WriterManager(new EfWriterRepository());
        UserManager userManager = new UserManager(new EfUserRepositroy());
        private readonly UserManager<AppUser> _userManager;
        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
		public IActionResult Index()
		{
            var usermail = User.Identity.Name;
            ViewBag.v = usermail;
            Context c = new Context();
            var writername = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.v2 = writername;
			return View();
		}
		public IActionResult WriterProfile()
		{
			return View();	
		}
		public IActionResult WriterMail()
		{
			return View();
		}
		[AllowAnonymous]
		public IActionResult Test()
		{
			return View();
		}
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
		{
			return PartialView();
		}
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
		[HttpGet]
		public async Task<IActionResult> WriterEditProfile()
		{
            var values=await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.mail = values.Email;
            model.namesurname = values.NameSurname;
            model.imageurl = values.ImageUrl;
            model.username = values.UserName;
            return View(model);
		}
        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel model)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.NameSurname = model.namesurname;
            values.ImageUrl = model.imageurl;
            values.Email = model.mail;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.password);
            var result = await _userManager.UpdateAsync(values);
            return RedirectToAction("Index", "Dashboard");
            //WriterValidate wl = new WriterValidate();
            //ValidationResult results = wl.Validate(p);
            //         if (results.IsValid)
            //         {
            //	wm.TUpdate(p);
            //             return RedirectToAction("Index","Dashboard");
            //         }
            //         else
            //         {
            //             foreach (var item in results.Errors)
            //             {
            //                 ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //             }
            //         }
            //         return View();

        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer w=new Writer();
            if (p.WriterImage != null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "www.root/WriteImageFiles/", newImageName);
                var stream=new FileStream(location,FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newImageName;

            }
            w.WriterName = p.WriterName;
            w.WriterMail=p.WriterMail;
            w.WriterStatus=true;
            w.WriterPassword=p.WriterPassword;
            w.WriterAbout=p.WriterAbout;
            wm.TAdd(w);
            return RedirectToAction("Index", "Dashboard");

        }
        //public async Task<IActionResult> LogOut()
        //{
        //    await 
        //}
    }
}
