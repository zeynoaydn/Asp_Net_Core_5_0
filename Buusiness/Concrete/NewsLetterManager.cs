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
	public class NewsLetterManager : INewsLetterService
	{
		INewsLetterDal _newsletterdal;
        public NewsLetterManager(INewsLetterDal newsLetter)
        {
            _newsletterdal = newsLetter;
        }
        public void NewsLetterAdd(NewsLetter newsLetter)
		{
			_newsletterdal.Insert(newsLetter);
		}
	}
}
