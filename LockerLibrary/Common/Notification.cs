using LockerLibrary.Locker;
using LockerLibrary.Package;
using LockerLibrary.Person;

namespace LockerLibrary.Common
{
    public class Notification
    {
        public string Code { get; }
        public IPackage Package { get; }
        public User User { get; }
        public ILocker Locker { get; }

        public Notification(string code, IPackage package, User user, ILocker locker)
        {
            Code = code;
            Package = package;
            User = user;
            Locker = locker;
        }
    }
}