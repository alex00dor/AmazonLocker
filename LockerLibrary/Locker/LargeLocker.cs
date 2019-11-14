using LockerLibrary.Common;

namespace LockerLibrary.Locker
{
    public class LargeLocker : BaseLocker
    {
        public LargeLocker(long id) : base(id, Size.Large)
        {
        }
    }
}