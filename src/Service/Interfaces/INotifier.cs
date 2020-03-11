using Service.Notifications;
using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface INotifier
    {
        bool IsThereNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
