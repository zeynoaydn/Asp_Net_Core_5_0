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
    public class MessageManager:IMessageService
    {
        IMessageDal _message;
        public MessageManager(IMessageDal message)
        {
            _message = message;
        }

        public List<Message> GetList()
        {
            return _message.GetListAll();
        }

        public List<Message> GetInboxListByWriter(string p)
        {
            return _message.GetListAll(x=>x.Receiver == p);

        }

        public void TAdd(Message t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Message t)
        {
            throw new NotImplementedException();
        }

        public Message TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Message t)
        {
            throw new NotImplementedException();
        }
    }
}
