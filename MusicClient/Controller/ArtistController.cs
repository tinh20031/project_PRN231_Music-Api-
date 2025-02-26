using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace MusicClient.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        public ArtistController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

		[HttpGet("{artistId}")]
		public async Task<IActionResult>GetArtist(string artistId)
        {
			var response = await _httpClient.GetAsync($"http://localhost:5000/api/spotify/artist/{artistId}");

			if (!response.IsSuccessStatusCode)
			{
				return StatusCode((int)response.StatusCode, "Lỗi khi gọi API Spotify");
			}

            var artistData = await response.Content.ReadAsStringAsync();
			return Ok(artistData);
		}

    }
}
