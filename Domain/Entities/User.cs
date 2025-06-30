namespace FakeStore.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public Name Name { get; set; }
    public Address Address { get; set; }
}

public class Name
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class Address
{
    public string City { get; set; }
    public string Street { get; set; }
    public int Number { get; set; }
    public string ZipCode { get; set; }
}