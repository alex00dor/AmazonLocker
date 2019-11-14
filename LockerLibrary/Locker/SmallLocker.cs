using LockerLibrary.Common;

namespace LockerLibrary.Locker
{
    public class SmallLocker : BaseLocker
    {
        public SmallLocker(long id) : base(id, Size.Small)
        {
        }
    }
}