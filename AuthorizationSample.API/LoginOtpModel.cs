using SnappFood.Clays.OTP.Models;

namespace AuthorizationSample.API;

public class LoginOtpModel : OtpModel

{
    public LoginOtpModel(string phone)
    {
        PhoneNumber = phone;
        ExpiresInMinutes = 5;
    }
    public int RepeatCount { get; set; }

    public override string GetKey()
    {
        return $"{PhoneNumber}";
    }

    public void Repeat()
    {
        RepeatCount++; 
    }
}