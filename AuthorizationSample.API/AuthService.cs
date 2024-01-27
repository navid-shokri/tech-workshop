using System.Net;
using System.Text.Json.Serialization;

namespace AuthorizationSample.API;

public class AuthService : IAuthService
{
    private readonly HttpClient _client;

    public AuthService(HttpClient client)
    {
        _client = client;
    }
    public async Task<UserData> IntrospectTokenAsync(string token)
    {
        var content = new FormUrlEncodedContent(new []
        {
            new KeyValuePair<string, string>("token", $"{token}"),
            new KeyValuePair<string, string>("client_id", $"express_resource"),
            new KeyValuePair<string, string>("client_secret", $"123qwe"),
        });
        var response = await _client.PostAsync("introspect", content);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            Console.Error.WriteLine($"Error on get token validity. status: {response.StatusCode}, response: {await response.Content.ReadAsStringAsync()}");
            return new UserData
            {
                Active = false
            };
        }

        return await response.Content.ReadFromJsonAsync<UserData>();
    }
}

public interface IAuthService
{
    Task<UserData> IntrospectTokenAsync(string token);
}

public class UserData
{
    public bool Active { get; set; }
    public string Scope { get; set; }
    public string Email { get; set; }
    public string CellPhone { get; set; }
    [JsonPropertyName("token_type")]
    public string TokenType { get; set; }
    [JsonPropertyName("exp")]
    public long Expiration { get; set; }
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    public string Reason { get; set; }
}