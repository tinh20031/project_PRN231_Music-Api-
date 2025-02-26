using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;

namespace api_music.Services
{
    public class SpotifyAuthService
    {
        private readonly string clientId = "2b6abdffc45442d1b78c519a5d9cec4d";
        private readonly string clientSecret = "4ff129f5a85f4b93a229dacd9c047862";
        private readonly string tokenURL = "https://accounts.spotify.com/api/token";

        public async Task<string> GetAccessTokenAsync()
        {
            using (var client = new HttpClient())
            {
                var credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));

                var request = new HttpRequestMessage(HttpMethod.Post, tokenURL);
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", credentials);
                request.Content = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("grant_type", "client_credentials")
            });

                var response = await client.SendAsync(request);
                var responseString = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Failed to get access token: " + responseString);
                }

                var json = JsonSerializer.Deserialize<JsonElement>(responseString);
                return json.GetProperty("access_token").GetString();
            }



        }



    }
}
