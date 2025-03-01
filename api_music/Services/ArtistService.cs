using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace api_music.Services
{
	public class ArtistService
	{
		private readonly HttpClient _httpClient;
		private readonly string apiBaseURL = "https://api.spotify.com/v1/";

		public ArtistService(HttpClient httpClient)
		{
			_httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
		}
	
		//lấy ca sĩ theo id 

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

		// lấy bài hát hay nhất của ca sĩ dựa theo id 
		public async Task<string> GetArtistTopAsync(string artistId, string accessToken)
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

				var response = await client.GetAsync($"{apiBaseURL}artists/{artistId}/top-tracks?market=VN");
				var responseString = await response.Content.ReadAsStringAsync();

				if (!response.IsSuccessStatusCode)
				{
					throw new Exception("lỗi k lấy dc data nghệ sĩ top : " + responseString);
				}

				return responseString;
			}
		}


		// lấy nhiều ca sĩ cùng lúc 
		

		public async Task<string> GetMultipleArtistsAsync(List<string> artistIds, string accessToken)
		{
			if (artistIds == null || artistIds.Count == 0)
			{
				throw new ArgumentException("Danh sách artistIds không được để trống.");
			}

			if (artistIds.Any(id => !IsBase62(id)))
			{
				throw new ArgumentException("Một hoặc nhiều ID không hợp lệ. ID phải theo chuẩn Base62.");
			}

			var request = new HttpRequestMessage(HttpMethod.Get, $"{apiBaseURL}artists?ids={string.Join(",", artistIds)}");
			request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

			var response = await _httpClient.SendAsync(request);
			var responseString = await response.Content.ReadAsStringAsync();

			if (!response.IsSuccessStatusCode)
			{
				throw new HttpRequestException($"Lỗi khi lấy dữ liệu nghệ sĩ ({response.StatusCode}): {responseString}");
			}

			return responseString;
		}

		private bool IsBase62(string input)
		{
			return Regex.IsMatch(input, "^[0-9A-Za-z]+$");
		}
	


	}
}
