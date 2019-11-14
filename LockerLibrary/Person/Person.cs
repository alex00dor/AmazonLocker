namespace LockerLibrary.Person
{
    public abstract class BasePerson : IPerson
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Address { get; }
        public string Apartment { get; }
        public string Phone { get; }
        public string Email { get; }

        public BasePerson(string firstName, string lastName, string address, string apartment, string phone, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Apartment = apartment;
            Phone = phone;
            Email = email;
        }
    }
}