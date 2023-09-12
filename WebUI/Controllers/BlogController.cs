using Buusiness.Concrete;
using Buusiness.ValidationRules;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebUI.Controllers
{
    [AllowAnonymous]

    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        Context c = new Context();

        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }
        //[AllowAnonymous]
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = bm.GetBlogByID(id);
            return View();
        }
        public IActionResult BlogListByWriter()
        {
            var username = User.Identity.Name;

            var usermail=c.Users.Where(x=>x.UserName== username).Select(y=>y.Email).FirstOrDefault();
            var writerID=c.Writers.Where(x=>x.WriterMail== usermail).Select(y=>y.WriterID).FirstOrDefault();

            //var writerid = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values=bm.GetListWithCategoryByWriterBM(writerID);
            return View(values);

        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            List<SelectListItem> categoryValue=(from x in cm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text=x.CategoryName,
                                                    Value=x.CategoryID.ToString()
                                                }).ToList();
            ViewBag.cv= categoryValue;
            return View();

        }
        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            var username = User.Identity.Name;

            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();

            BlogValidator validationrules = new BlogValidator();
            ValidationResult result = validationrules.Validate(p);
            
            if (result.IsValid)
            {
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = writerID;
                bm.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }   
        public IActionResult DeleteBlog(int id)
        {
            var blogValues=bm.TGetById(id);
            bm.TDelete(blogValues);
            return RedirectToAction("BlogListByWriter");
        }
        [HttpGet]
        public IActionResult EditBlog(int id) 
        {
            var values=bm.TGetById(id);
            List<SelectListItem> categoryValue = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.cv = categoryValue;
            return View(values);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            var username = User.Identity.Name;

            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();


            p.WriterID= writerID;
            p.BlogStatus = true;
            p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            bm.TUpdate(p);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
