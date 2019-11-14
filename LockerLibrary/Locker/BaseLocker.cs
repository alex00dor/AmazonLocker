using System;
using LockerLibrary.Common;
using LockerLibrary.Package;
using LockerLibrary.Person;

namespace LockerLibrary.Locker
{
    public abstract class BaseLocker : ILocker
    {
        public long Id { get; }
        public IPackage Package { get; protected set; }
        public Size Size { get; }
        public bool IsOpen { get; protected set; }
        public IPerson Receiver { get; protected set; }

        protected BaseLocker(long id, Size size)
        {
            Id = id;
            Size = size;
        }

        public bool IsFull()
        {
            return Package != null || Receiver != null;
        }

        public bool Open()
        {
            IsOpen = true;
            return true;
        }

        public bool PutPackage(IPackage package, IPerson receiver)
        {
            if (IsOpen)
            {
                Package = package;
                Receiver = receiver;
                return true;
            }

            return false;
        }

        public IPackage RetrievePackage()
        {
            if (!IsOpen)
            {
                throw new Exception("Locker door is closed");
            }

            IPackage package = Package;

            Package = null;
            Receiver = null;

            return package;
        }

        public bool Close()
        {
            IsOpen = false;
            return true;
        }
    }
}