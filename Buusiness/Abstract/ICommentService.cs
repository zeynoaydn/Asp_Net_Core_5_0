using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buusiness.Abstract
{
	public interface ICommentService
	{
		void CommentAdd(Comment comment);
		//void BlogDelete(Blog blog);
		//void BlogUpdate(Blog blog);
		List<Comment> GetList(int id);
        //Blog GetById(int id);

        List<Comment> GetCommentWithBlog();

    }
}
