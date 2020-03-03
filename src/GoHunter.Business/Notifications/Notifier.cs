using GoHunter.Business.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GoHunter.Business.Notifications
{
    public class Notifier : INotifier
    {
        private List<Notification> _notifications;

        public Notifier()
        {
            _notifications = new List<Notification>();
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }
        public List<Notification> GetNotifications()
        {
            return _notifications;
        }           

        public bool IsThereNotification()
        {
            return _notifications.Any();
        }
    }
}
