using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebUI.Models;

namespace WebUI.ViewComponents
{
	public class CommentList:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var commnetValues = new List<UserComment>
			{
				new UserComment
				{
					ID = 1,
					Username="Zeynep"
				},
				new UserComment
				{
					ID = 2,
					Username="Mamic"
				},
				new UserComment
				{
					ID = 3,
					Username="Bihter"
				},
			};
			return View(commnetValues);	
		}
	}
}
