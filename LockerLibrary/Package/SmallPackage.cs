using LockerLibrary.Common;

namespace LockerLibrary.Package
{
    public class SmallPackage : BasePackage
    {
        public SmallPackage(string barcode, string receiverFirstName, string receiverLastName, string receiverAddress,
            string receiverApartment, string receiverPhone, string receiverEmail) : base(barcode, receiverFirstName,
            receiverLastName, receiverAddress, receiverApartment, receiverPhone, receiverEmail, Size.Small)
        {
        }
    }
}