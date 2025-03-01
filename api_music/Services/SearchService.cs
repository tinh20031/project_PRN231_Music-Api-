using System.Net.Http.Headers;

namespace api_music.Services
{
	public class SearchService
	{
		private readonly HttpClient _httpClient;
		private readonly string apiBaseURL = "https://api.spotify.com/v1/";
		public SearchService(HttpClient httpClient)
		{
			_httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
		}
		public async Task<string> SearchAsync(string query, string accessToken)
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
				string type = "track,artist,album,playlist,show,episode,audiobook";
				var response = await client.GetAsync($"{apiBaseURL}search?q={Uri.EscapeDataString(query)}&type={type}&limit=10");
				var responseString = await response.Content.ReadAsStringAsync();

				if (!response.IsSuccessStatusCode)
				{
					throw new Exception("lỗi k lấy dc data playlist: " + responseString);
				}

				return responseString;
			}
		}
	}
}
