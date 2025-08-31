using Microsoft.Extensions.Options;
using SnappFood.Clays.OTP;
using SnappFood.Clays.OTP.Service;
using SnappFood.Clays.OTP.Storage;

namespace AuthorizationSample.API;

public class LoginOtpService : IPersonable
{
    private IConfigurationSection? _person;
    public LoginOtpService(IConfiguration configuration)
    {
        _person = configuration.GetSection("info");
    }


    public string GetFullName() => $"{_person["Name"]} {_person["Family"]}";
}