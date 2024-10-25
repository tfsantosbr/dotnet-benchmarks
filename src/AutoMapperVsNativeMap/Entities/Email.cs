namespace AutoMapperVsNativeMap.Entities;

public record Email(string Address)
{
    public string Address { get; private set; } = Address;
}
