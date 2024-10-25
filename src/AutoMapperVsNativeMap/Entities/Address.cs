namespace AutoMapperVsNativeMap.Entities;

public record Address(string Street, string Number, string City, string State, string ZipCode)
{
    public string Street { get; private set; } = Street;
    public string Number { get; private set; } = Number;
    public string City { get; private set; } = City;
    public string State { get; private set; } = State;
    public string ZipCode { get; private set; } = ZipCode;
}
