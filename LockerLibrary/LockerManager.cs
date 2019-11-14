using System;
using System.Collections.Generic;
using System.Text;
using LockerLibrary.Common;
using LockerLibrary.Locker;
using LockerLibrary.Package;
using LockerLibrary.Person;

namespace LockerLibrary
{
    public class LockerManager
    {
        private const int CodeLen = 10;
        private Queue<SmallLocker> SmallLockers { get; }
        private Queue<MediumLocker> MediumLockers { get; }
        private Queue<LargeLocker> LargeLockers { get; }
        private Queue<XLargeLocker> XLargeLockers { get; }
        private Dictionary<string, ILocker> FilledLockers { get; }
        private Dictionary<string, List<User>> Users { get; }
        private HashSet<INotificationManager> NotificationManagers { get; set; }

        public LockerManager()
        {
            SmallLockers = new Queue<SmallLocker>();
            MediumLockers = new Queue<MediumLocker>();
            LargeLockers = new Queue<LargeLocker>();
            XLargeLockers = new Queue<XLargeLocker>();
            FilledLockers = new Dictionary<string, ILocker>();
            Users = new Dictionary<string, List<User>>();
        }

        public void AddNotificationManager(INotificationManager manager) => NotificationManagers.Add(manager);
        public void RemoveNotificationManager(INotificationManager manager) => NotificationManagers.Remove(manager);

        private void SendNotification(Notification notification)
        {
            foreach (var manager in NotificationManagers)
            {
                manager.SendNotification(this, notification);
            }
        }
        public void AddLocker(ILocker locker)
        {
            switch (locker.Size)
            {
                case Size.Small:
                    SmallLockers.Enqueue((SmallLocker) locker);
                    break;
                case Size.Medium:
                    MediumLockers.Enqueue((MediumLocker) locker);
                    break;
                case Size.Large:
                    LargeLockers.Enqueue((LargeLocker) locker);
                    break;
                case Size.XLarge:
                    XLargeLockers.Enqueue((XLargeLocker) locker);
                    break;
            }
        }

        public void AddLockers(List<ILocker> lockers) => lockers.ForEach(AddLocker);

        public void AddUser(User user)
        {
            if(!Users.ContainsKey(user.Apartment))
                Users[user.Apartment] = new List<User>();
            Users[user.Apartment].Add(user);
        }
        public void AddUsers(List<User> users) => users.ForEach(AddUser);

        public List<User> GetUsersByApartment(string apartment) =>
            Users.ContainsKey(apartment) ? Users[apartment] : new List<User>();

        public IPackage PickUpPackage(Notification notification) => PickUpPackage(notification.Code);

        public IPackage PickUpPackage(string code)
        {
            if(!FilledLockers.ContainsKey(code))
                throw new Exception("Code is not exist");
            ILocker locker = FilledLockers[code];
            locker.Open();
            IPackage package = locker.RetrievePackage();
            locker.Close();
            FilledLockers.Remove(code);
            AddLocker(locker);

            return package;
        }

        private ILocker GetAvailableLocker(Size size)
        {
            ILocker result = null;

            if (size == Size.Small && SmallLockers.Count > 0)
                result = SmallLockers.Dequeue();

            if (result == null && size == Size.Medium && MediumLockers.Count > 0)
                result = MediumLockers.Dequeue();     
            
            if (result == null && size == Size.Large && LargeLockers.Count > 0)
                result = LargeLockers.Dequeue();    
            
            if (result == null && size == Size.XLarge && XLargeLockers.Count > 0)
                result = XLargeLockers.Dequeue();

            if(result == null)
                throw new Exception("All lockers are full");

            return result;
        }

        private string GenerateCode(int len)
        {
            Random random = new Random();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < len; i++)
                sb.Append(random.Next(0, 10));

            return sb.ToString();
        }

        public void PutPackage(IPackage package, User user)
        {
            ILocker locker = GetAvailableLocker(package.Size);
            locker.Open();
            locker.PutPackage(package, user);
            locker.Close();
            string code = GenerateCode(CodeLen);
            while (!FilledLockers.ContainsKey(code))
                code = GenerateCode(CodeLen);
            FilledLockers[code] = locker;
            Notification notification = new Notification(code, package, user, locker);
            SendNotification(notification);
        }
    }
}