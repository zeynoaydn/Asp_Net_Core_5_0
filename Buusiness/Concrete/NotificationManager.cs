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
    public class NotificationManager : INotificationService
    {
        INotificationDal _notidal;
        public NotificationManager(INotificationDal notificationDal)
        {
            _notidal = notificationDal;
        }
        public List<Notification> GetList()
        {
            return _notidal.GetListAll();
        }

        public void TAdd(Notification t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Notification t)
        {
            throw new NotImplementedException();
        }

        public Notification TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Notification t)
        {
            throw new NotImplementedException();
        }
    }
}
