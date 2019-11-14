using System;
using System.Collections.Generic;
using LockerLibrary.Common;
using LockerLibrary.Package;

namespace LockerLibrary.Person
{
    public class User : BasePerson
    {
        private Dictionary<LockerManager, List<Notification>> Notifications { get; }
        public LockerManager LockerManager { get; set; }

        public User(string firstName, string lastName, string address, string apartment, string phone, string email) :
            base(firstName, lastName, address, apartment, phone, email)
        {
            Notifications = new Dictionary<LockerManager, List<Notification>>();
        }

        public void AddNotification(LockerManager from, Notification notification)
        {
            if (!Notifications.ContainsKey(from))
                Notifications[from] = new List<Notification>();
            Notifications[from].Add(notification);
        }

        private void VerifyLockerManager()
        {
            if (LockerManager == null)
                throw new Exception("LockerManager is null");
        }

        public List<Notification> GetNotifications()
        {
            VerifyLockerManager();
            return Notifications[LockerManager];
        }

        public IPackage PickUpPackage(Notification notification)
        {
            VerifyLockerManager();
            return LockerManager.PickUpPackage(notification);
        }

        public List<IPackage> PickAllPackages()
        {
            VerifyLockerManager();

            List<IPackage> result = new List<IPackage>();
            if (!Notifications.ContainsKey(LockerManager) || Notifications[LockerManager].Count == 0)
                throw new Exception("Not found notifications for this locker");

            Notifications[LockerManager].ForEach(n => result.Add(PickUpPackage(n)));

            return result;
        }

        public void SetLocketManger(LockerManager lockerManager) => LockerManager = lockerManager;

        public void ReleaseLocketManger() => LockerManager = null;
    }
}