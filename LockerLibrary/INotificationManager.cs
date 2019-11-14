using LockerLibrary.Common;
using LockerLibrary.Person;

namespace LockerLibrary
{
    public interface INotificationManager
    {
        void SendNotification(LockerManager manager, Notification notification);
    }
}