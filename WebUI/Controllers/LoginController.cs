﻿using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;
        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(UserSignInViewModel p)
		{
			if(ModelState.IsValid)
			{
                var result = await _signInManager.PasswordSignInAsync(p.username, p.password, false, true);
				if(result.Succeeded)
				{
					return RedirectToAction("Index", "Dashboard");
				}
				else
				{
                    return RedirectToAction("Index", "Login");

                }
            }
			return View();
        }
		public async Task<IActionResult> LogOut()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Login");
		}
		public IActionResult AccessDenied()
        {
            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult> Index(Writer p)
        //{

        //	Context c=new Context();
        //	var data = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail &&
        //		x.WriterPassword == p.WriterPassword);
        //	if (data!= null)
        //	{
        //		var claims = new List<Claim>
        //		{
        //			new Claim(ClaimTypes.Name,p.WriterMail)
        //		};
        //		var useridentity = new ClaimsIdentity(claims, "a");
        //		ClaimsPrincipal principal=new ClaimsPrincipal(useridentity);
        //		await HttpContext.SignInAsync(principal);
        //		return RedirectToAction("Index", "Dashboard");
        //	}
        //	else
        //	{
        //		return View();
        //	}
        //}
    }
}
