using System.Text;
using System;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Builder Pattern Test ---");

        UserBuilder builder = new UserBuilder("John", "Doe");

        User user1 = builder
                        .WithAge(30)
                        .WithEmail("john@example.com")
                        .Build();

        Console.WriteLine(user1.ToString());

        User user2 = new UserBuilder("Jane", "Smith")
                        .WithAddress("123 Main St")
                        .Build();

        Console.WriteLine(user2.ToString());
    }
    public class User
    {
        //required and immutable
        public string FirstName{get;}
        public string LastName{get;}
        // not required and immutable
        public int? Age{get;}
        public string? Address{get;}
        public string? EmailAddress{get;}
        public User (string firstName,string lastName,int? age,string? address,string? emailAddress)
        {
             FirstName=firstName;
             LastName=lastName;
             Age=age;
             Address=address;
             EmailAddress=emailAddress;
        }
        public override string ToString()
        {
            return $"User: {FirstName} {LastName} | Age: {Age?.ToString() ?? "N/A"} | Email: {EmailAddress ?? "N/A"} | Address: {Address ?? "N/A"}";
        }
    }
    public class UserBuilder
    {
        private string _firstName;
        private string _lastName;
        private int? _age;
        private string? _address;
        private string? _emailAddress;
        public UserBuilder(string firstName,string lastName)
        {
            if(string.IsNullOrWhiteSpace(firstName)|| string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("First and Last Name are required!");
            }    
            _firstName=firstName;
            _lastName=lastName;
        }
        public UserBuilder WithAge(int age)
        {
            _age=age;
            return this;
        }
        public UserBuilder WithAddress(string address)
        {
            _address = address;
            return this;
        }
        public UserBuilder WithEmail(string email)
        {
            _emailAddress = email;
            return this;
        }
        public User Build()
        {
            return new User(_firstName, _lastName, _age, _address, _emailAddress);
        }
    }   
}



