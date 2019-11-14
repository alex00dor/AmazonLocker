using System;
using System.Collections.Generic;
using System.Linq;
using LockerLibrary.Package;

namespace LockerLibrary.Person
{
    public class DeliveryMan : BasePerson
    {
        public Queue<IPackage> Packages { get; set; }
        public Queue<IPackage> Returns { get; set; }
        public LockerManager LockerManager { get; set; }

        public DeliveryMan(string firstName, string lastName, string address, string apartment, string phone,
            string email) : base(firstName, lastName, address, apartment, phone, email)
        {
        }

        private void VerifyLockerManager()
        {
            if (LockerManager == null)
                throw new Exception("LockerManager is null");
        }

        public void SetLocketManger(LockerManager lockerManager) => LockerManager = lockerManager;
        public void ReleaseLocketManger() => LockerManager = null;

        public void DeliveryAllToLocker()
        {
            while (Packages.Count > 0)
            {
                IPackage package = Packages.Dequeue();
                PutPackageToLocker(package);
            }
        }

        public void PutPackageToLocker(IPackage package)
        {
            VerifyLockerManager();
            List<User> users = LockerManager.GetUsersByApartment(package.ReceiverApartment);
            User user = users
                .FirstOrDefault(u => u.FirstName == package.ReceiverFirstName && u.LastName == package.ReceiverLastName);
            if (users.Count == 0 || user == null)
            {
                ReturnPackage(package);
                return;
            }
            
            try
            {
                LockerManager.PutPackage(package, user);
            }
            catch (Exception e)
            {
                ReturnPackage(package);
            }
        }

        private void ReturnPackage(IPackage package) => Returns.Enqueue(package);
    }
}