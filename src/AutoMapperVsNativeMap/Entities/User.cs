namespace AutoMapperVsNativeMap.Entities;

public record User(Guid Id, string Name, Email Email, Address Address, List<Phone> Phones)
{
    public Guid Id { get; private set; } = Id;
    public string Name { get; private set; } = Name;
    public Email Email { get; private set; } = Email;
    public Address Address { get; private set; } = Address;
    public List<Phone> Phones { get; private set; } = Phones;

    public User(string name, Email email, Address address, List<Phone> phones)
        : this(Guid.NewGuid(), name, email, address, phones ?? [])
    {
    }
}
