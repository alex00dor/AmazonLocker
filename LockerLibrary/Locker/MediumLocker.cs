using LockerLibrary.Common;

namespace LockerLibrary.Locker
{
    public class MediumLocker : BaseLocker
    {
        public MediumLocker(long id) : base(id, Size.Medium)
        {
        }
    }
}