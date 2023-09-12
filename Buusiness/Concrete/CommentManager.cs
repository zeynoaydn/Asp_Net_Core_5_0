using Buusiness.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buusiness.Concrete
{
	public class CommentManager : ICommentService
	{
		ICommnetDal _commnetDal;
        public CommentManager(ICommnetDal commnetDal)
        {
            _commnetDal = commnetDal;
        }
        public void CommentAdd(Comment comment)
		{
			_commnetDal.Insert(comment);
		}

        public List<Comment> GetCommentWithBlog()
        {
            return _commnetDal.GetListWithBlog();
        }

        public List<Comment> GetList(int id)
		{
			return _commnetDal.GetListAll(x=>x.BlogID==id);
		}


	}
}
