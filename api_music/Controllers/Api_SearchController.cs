using api_music.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_music.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class Api_SearchController : ControllerBase
	{
		private readonly SearchService _searchService;

		// xác minh access token 
		private readonly SpotifyAuthService _spotifyAuthService;
		public Api_SearchController(SearchService searchService, SpotifyAuthService spotifyAuthService)
		{
			_searchService = searchService ?? throw new ArgumentNullException(nameof(searchService)); // ✅ Đúng
			_spotifyAuthService = spotifyAuthService ?? throw new ArgumentNullException(nameof(spotifyAuthService));
		}


		[HttpGet("search")]
		public async Task<IActionResult> Search([FromQuery] string query)
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return BadRequest("Query cannot be empty.");
			}

			var token = await _spotifyAuthService.GetAccessTokenAsync();
			var result = await _searchService.SearchAsync(query, token);
			return Ok(result);
		}
	}

}

