using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface INotificationDal : IGenericDal<Notification>
    {
        int NotificationCountByStatusFalse();
        List<Notification> GetAllNotificationsByStatusFalse();
        void NotificationStatusChangeToTrue(int id);
        void NotificationStatusChangeToFalse(int id);
    }
}