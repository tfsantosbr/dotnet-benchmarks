using AutoMapper;
using AutoMapperVsNativeMap.Entities;
using AutoMapperVsNativeMap.Mappers;
using AutoMapperVsNativeMap.Models;
using BenchmarkDotNet.Attributes;

namespace AutoMapperVsNativeMap;

[MemoryDiagnoser]
public class AutomapperVsNativeMap
{
    private readonly List<User> users;
    private readonly Mapper mapper;

    public AutomapperVsNativeMap()
    {
        mapper = ConfigureAutomapper();
        users = GenerateExampleUsers(1_000_000);
    }

    // Benchmarks

    [Benchmark]
    public List<UserModel> Autommapper() =>
        mapper.Map<List<UserModel>>(users);

    [Benchmark]
    public List<UserModel> NativeExtensionMap() =>
        users.Select(user => user.ToModel()).ToList();

    [Benchmark]
    public List<UserModel> NativeSimpleMap()
    {
        var models = new List<UserModel>();

        foreach (var user in users)
        {
            // Map User entity to UserModel
            var userModel = new UserModel(
                user.Id,
                user.Name,
                new EmailModel(user.Email!.Address),
                new AddressModel(
                    user.Address!.Street,
                    user.Address!.Number,
                    user.Address!.City,
                    user.Address!.State,
                    user.Address!.ZipCode
                ),
                []
            );

            foreach (var phone in user.Phones)
            {
                userModel.Phones.Add(new PhoneModel(phone.CountryCode, phone.AreaCode, phone.Number));
            }

            models.Add(userModel);
        }

        return models;
    }

    // Private Methods

    private static List<User> GenerateExampleUsers(int count)
    {
        var users = new List<User>(capacity: count);

        for (int i = 0; i < count; i++)
        {
            var email = new Email($"example{i}@domain.com");
            var address = new Address("Example Street", "123", "Example City", "Example State", "12345-678");
            var phones = new List<Phone>
            {
                new("55", "415", $"987654{i:D6}"),
                new("55", "415", $"912345{i:D6}")
            };

            var user = new User($"User {i}", email, address, phones);

            users.Add(user);
        }

        return users;
    }

    private static Mapper ConfigureAutomapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<UserAutomapperMap>();
        });

        return new Mapper(config);
    }
}

