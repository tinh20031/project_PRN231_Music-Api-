using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace api_music.Services
{
	public class ShowServices
	{

		private readonly HttpClient _httpClient;
		private readonly string apiBaseURL = "https://api.spotify.com/v1/";
		public ShowServices(HttpClient httpClient)
		{
			_httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
		}

		//lấy podcast theo id 
		public async Task<string> GetShowAsync(string PodCastId, string accessToken)
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

				var response = await client.GetAsync($"{apiBaseURL}shows/{PodCastId}");
				var responseString = await response.Content.ReadAsStringAsync();

				if (!response.IsSuccessStatusCode)
				{
					throw new Exception("lỗi k lấy dc data podcast: " + responseString);
				}

				return responseString;
			}
		}


		//lấy nhiều podcast 
		public async Task<string> GetMultiplePodcastsAsync(List<string> PodCastId, string accessToken)
		{
			if (PodCastId == null || PodCastId.Count == 0)
			{
				throw new ArgumentException("Danh sách PodCastId không được để trống.");
			}

			if (PodCastId.Any(id => !IsBase62(id)))
			{
				throw new ArgumentException("Một hoặc nhiều ID không hợp lệ. ID phải theo chuẩn Base62.");
			}

			var request = new HttpRequestMessage(HttpMethod.Get, $"{apiBaseURL}shows?ids={string.Join(",", PodCastId)}");
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
