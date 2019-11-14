using LockerLibrary.Common;
using LockerLibrary.Person;

namespace LockerLibrary
{
    public class NotificationManager : INotificationManager
    {
        private NotificationManager _notificationManager;

        public NotificationManager Instance
        {
            get
            {
                if(_notificationManager == null)
                    _notificationManager = new NotificationManager();
                return _notificationManager;
            }
        }

        private NotificationManager()
        {
        }
        
        public void SendNotification(LockerManager manager, Notification notification)
        {
            notification.User.AddNotification(manager, notification);
        }
    }
}