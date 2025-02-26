using System.Net.Http.Headers;

namespace api_music.Services
{
    public class ArtistService
    {
        private readonly string apiBaseURL = "https://api.spotify.com/v1/";
        public async Task<string> GetArtistAsync(string artistId, string accessToken)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var response = await client.GetAsync($"{apiBaseURL}artists/{artistId}");
                var responseString = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("lỗi k lấy dc data nghệ sĩ: " + responseString);
                }

                return responseString;
            }
        }
    }
}
