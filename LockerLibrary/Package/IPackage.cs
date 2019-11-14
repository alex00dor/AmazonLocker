using LockerLibrary.Common;

namespace LockerLibrary.Package
{
    public interface IPackage
    {
        string Barcode { get; }
        string ReceiverFirstName { get; }
        string ReceiverLastName { get; }
        string ReceiverAddress { get; }
        string ReceiverApartment { get; }
        string ReceiverPhone { get; }
        string ReceiverEmail { get; }
        Size Size { get; }
    }
}