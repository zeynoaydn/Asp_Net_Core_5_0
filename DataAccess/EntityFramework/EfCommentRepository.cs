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
    public class EfCommentRepository : GenericRepository<Comment>, ICommnetDal
    {
        public List<Comment> GetListWithBlog()
        {
            using (var c = new Context())
            {
                return c.Comments.Include(c => c.Blog).ToList();
            }
        }
    }
}
