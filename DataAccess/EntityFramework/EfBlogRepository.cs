using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repositories;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
	public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
	{
		public List<Blog> GetListWithCatgeory()
		{
			using(var c=new Context())
			{
				return c.Blogs.Include(c=>c.Category).ToList();
			}
		}

        public List<Blog> GetListWithCatgeoryByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Blogs.Include(c => c.Category).Where(x=>x.WriterID==id).ToList();
            }
        }
    }
}
