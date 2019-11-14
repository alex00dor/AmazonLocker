using LockerLibrary.Common;

namespace LockerLibrary.Package
{
    public abstract class BasePackage : IPackage
    {
        public string Barcode { get; }
        public string ReceiverFirstName { get; }
        public string ReceiverLastName { get; }
        public string ReceiverAddress { get; }
        public string ReceiverApartment { get; }
        public string ReceiverPhone { get; }
        public string ReceiverEmail { get; }
        public Size Size { get; }

        protected BasePackage(string barcode, string receiverFirstName, string receiverLastName, string receiverAddress, string receiverApartment, string receiverPhone, string receiverEmail, Size size)
        {
            Barcode = barcode;
            ReceiverFirstName = receiverFirstName;
            ReceiverLastName = receiverLastName;
            ReceiverAddress = receiverAddress;
            ReceiverApartment = receiverApartment;
            ReceiverPhone = receiverPhone;
            ReceiverEmail = receiverEmail;
            Size = size;
        }
    }
}