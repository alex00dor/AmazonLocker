using LockerLibrary.Common;

namespace LockerLibrary.Locker
{
    public class XLargeLocker : BaseLocker
    {
        public XLargeLocker(long id) : base(id, Size.XLarge)
        {
        }
    }
}