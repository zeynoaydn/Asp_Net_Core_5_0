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
    public class Message2Manager:IMessage2Service
    {
        IMessage2Dal _message;
        public Message2Manager(IMessage2Dal message)
        {
            _message = message;
        }

        public List<Message2> GetInboxListByWriter(int id)
        {
            return _message.GetInBoxWithmessageByWriter(id);
        }

        public List<Message2> GetList()
        {
           return _message.GetListAll();
        }

        public List<Message2> GetSendBoxListByWriter(int id)
        {
            return _message.GetSendBoxWithmessageByWriter(id);
        }

        public void TAdd(Message2 t)
        {
            _message.Insert(t);
        }

        public void TDelete(Message2 t)
        {
            throw new NotImplementedException();
        }

        public Message2 TGetById(int id)
        {
            return _message.GetByID(id);
        }

        public void TUpdate(Message2 t)
        {
            throw new NotImplementedException();
        }
    }
}
