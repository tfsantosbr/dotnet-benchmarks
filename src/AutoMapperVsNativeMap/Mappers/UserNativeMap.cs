using AutoMapperVsNativeMap.Entities;
using AutoMapperVsNativeMap.Models;

namespace AutoMapperVsNativeMap.Mappers;

public static class UserNativeMap
{
    public static UserModel ToModel(this User user) =>
        new(
            user.Id,
            user.Name,
            user.Email!.ToModel(),
            user.Address!.ToModel(),
            user.Phones!.Select(phone => phone.ToModel()).ToList()
        );

    public static EmailModel ToModel(this Email email) =>
        new(email.Address);

    public static AddressModel ToModel(this Address address) =>
        new(address.Street, address.Number, address.City, address.State, address.ZipCode);

    public static PhoneModel ToModel(this Phone phone) =>
        new(phone.CountryCode, phone.AreaCode, phone.Number);
}