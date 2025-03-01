using api_music.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_music.Controllers
{
	[Route("api/spotify")]
	[ApiController]
	public class Api_ShowController : ControllerBase
	{
		// lấy data podcast 
		private readonly ShowServices _showServices;

		// xác minh access token 
		private readonly SpotifyAuthService _spotifyAuthService;

		public Api_ShowController(ShowServices showServices, SpotifyAuthService spotifyAuthService)
		{
			_showServices = showServices ?? throw new ArgumentNullException(nameof(showServices));
			_spotifyAuthService = spotifyAuthService ?? throw new ArgumentNullException(nameof(spotifyAuthService));
		}

		// get api một podcast theo id 
		[HttpGet("podcast/{PodCastId}")]
		public async Task<IActionResult> GetArtist(string PodCastId)
		{
			var token = await _spotifyAuthService.GetAccessTokenAsync();
			var artistData = await _showServices.GetShowAsync(PodCastId, token);
			return Ok(artistData);
		}


		//lấy nhiều podcast cùng lúc 
		[HttpPost("MultiPodcast")]
		public async Task<IActionResult> GetManyArtist([FromBody] List<string> PodCastId)
		{
			if (PodCastId == null)
			{
				return BadRequest("PodCastId nhận được là null.");
			}
			if (PodCastId.Count == 0)
			{
				return BadRequest("Danh sách ID podcast rỗng.");
			}

			try
			{
				var token = await _spotifyAuthService.GetAccessTokenAsync();
				var artistData = await _showServices.GetMultiplePodcastsAsync(PodCastId, token);
				return Ok(artistData);
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
			catch (HttpRequestException ex)
			{
				return StatusCode(502, ex.Message);
			}
			catch (Exception ex)
			{
				return StatusCode(500, "Lỗi hệ thống: " + ex.Message);
			}
		}

	}
}
