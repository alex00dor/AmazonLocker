using LockerLibrary.Common;
using LockerLibrary.Package;
using LockerLibrary.Person;

namespace LockerLibrary.Locker
{
    public interface ILocker
    {
        long Id { get; }
        IPackage Package { get; }
        Size Size { get; }
        bool IsOpen { get; }
        IPerson Receiver { get; }

        bool IsFull();
        bool Open();
        bool PutPackage(IPackage package, IPerson receiver);
        IPackage RetrievePackage();
        bool Close();
    }
}