namespace AutoMapperVsNativeMap.Models;

using System;
using System.Collections.Generic;

public record UserModel(Guid Id, string Name, EmailModel Email, AddressModel Address, List<PhoneModel> Phones);