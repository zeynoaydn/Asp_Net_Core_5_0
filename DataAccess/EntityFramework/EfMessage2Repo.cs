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
    public class EfMessage2Repo : GenericRepository<Message2>, IMessage2Dal
    {
        public List<Message2> GetSendBoxWithmessageByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Message2s.Include(c => c.ReceiverUser).Where(x => x.SenderID == id).ToList();
            }
        }

        public List<Message2> GetInBoxWithmessageByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Message2s.Include(c => c.SenderUser).Where(x => x.ReceiverID == id).ToList();
            }
        }
    }
}
