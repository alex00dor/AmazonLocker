using LockerLibrary.Common;

namespace LockerLibrary.Package
{
    public class LargePackage : BasePackage
    {
        public LargePackage(string barcode, string receiverFirstName, string receiverLastName, string receiverAddress,
            string receiverApartment, string receiverPhone, string receiverEmail) : base(barcode,
            receiverFirstName, receiverLastName, receiverAddress, receiverApartment, receiverPhone, receiverEmail, Size.Large)
        {
        }
    }
}