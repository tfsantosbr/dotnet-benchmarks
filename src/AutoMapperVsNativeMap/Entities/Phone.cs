namespace AutoMapperVsNativeMap.Entities;

public record Phone(string CountryCode, string AreaCode, string Number)
{
    public string CountryCode { get; private set; } = CountryCode;
    public string AreaCode { get; private set; } = AreaCode;
    public string Number { get; private set; } = Number;
}