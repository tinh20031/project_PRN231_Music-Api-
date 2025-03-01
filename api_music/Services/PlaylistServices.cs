using System.Net.Http.Headers;

namespace api_music.Services
{
	public class PlaylistServices
	{
		private readonly HttpClient _httpClient;
		private readonly string apiBaseURL = "https://api.spotify.com/v1/";

		public PlaylistServices(HttpClient httpClient)
		{
			_httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
		}
		//lấy 1 playlist 
		public async Task<string> GetPlaylistAsync(string playlistId, string accessToken)
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

				var response = await client.GetAsync($"{apiBaseURL}playlists/{playlistId}");
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
