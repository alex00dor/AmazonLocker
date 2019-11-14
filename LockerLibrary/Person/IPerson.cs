namespace LockerLibrary.Person
{
    public interface IPerson
    {
        int Id { get; }
        string FirstName { get; }
        string LastName { get; }
        string Address { get; }
        string Apartment { get; }
        string Phone { get; }
        string Email { get; }
    }
}