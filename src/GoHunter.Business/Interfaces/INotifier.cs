using GoHunter.Business.Notifications;
using System.Collections.Generic;

namespace GoHunter.Business.Interfaces
{
    public interface INotifier
    {
        bool IsThereNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
