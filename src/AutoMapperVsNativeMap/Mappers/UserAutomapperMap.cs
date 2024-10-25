using AutoMapper;
using AutoMapperVsNativeMap.Entities;
using AutoMapperVsNativeMap.Models;

namespace AutoMapperVsNativeMap.Mappers;

public class UserAutomapperMap : Profile
{
    public UserAutomapperMap()
    {
        CreateMap<Email, EmailModel>();
        CreateMap<Address, AddressModel>();
        CreateMap<Phone, PhoneModel>();
        CreateMap<User, UserModel>();
    }
}
