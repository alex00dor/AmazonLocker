using LockerLibrary.Common;

namespace LockerLibrary.Package
{
    public class MediumPackage : BasePackage
    {
        public MediumPackage(string barcode, string receiverFirstName, string receiverLastName, string receiverAddress,
            string receiverApartment, string receiverPhone, string receiverEmail) : base(barcode, receiverFirstName,
            receiverLastName, receiverAddress, receiverApartment, receiverPhone, receiverEmail, Size.Medium)
        {
        }
    }
}