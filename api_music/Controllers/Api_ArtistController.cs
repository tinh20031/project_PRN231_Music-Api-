using api_music.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_music.Controllers
{
    [Route("api/spotify")]
    [ApiController]
    public class Api_ArtistController : ControllerBase
    {
		// lấy data nghệ sĩ 
		private readonly ArtistService _artistService;

		// xác minh access token 
		private readonly SpotifyAuthService _spotifyAuthService;

		public Api_ArtistController(ArtistService artistService, SpotifyAuthService spotifyAuthService)
		{
			_artistService = artistService ?? throw new ArgumentNullException(nameof(artistService));
			_spotifyAuthService = spotifyAuthService ?? throw new ArgumentNullException(nameof(spotifyAuthService));
		}
		// get api một nghệ sĩ theo id 
		[HttpGet("artist/{artistId}")]
        public async Task<IActionResult> GetArtist(string artistId)
        {
            var token = await _spotifyAuthService.GetAccessTokenAsync();
            var artistData = await _artistService.GetArtistAsync(artistId, token);
            return Ok(artistData);
        }

		//lấy bài hát hay nhất của nghệ sĩ 
		[HttpGet("ArtistTop/{artistId}")]
		public async Task<IActionResult> GetArtistTop(string artistId)
		{
			var token = await _spotifyAuthService.GetAccessTokenAsync();
			var artistData = await _artistService.GetArtistTopAsync(artistId, token);
			return Ok(artistData);
		}

		//lấy nhiều nghệ sĩ cùng lúc 
		[HttpPost("MultiArtist")]
		public async Task<IActionResult> GetManyArtist([FromBody] List<string> artistIds)
		{
			if (artistIds == null || artistIds.Count == 0)
			{
				return BadRequest("Danh sách ID nghệ sĩ không hợp lệ.");
			}

			try
			{
				var token = await _spotifyAuthService.GetAccessTokenAsync();
				var artistData = await _artistService.GetMultipleArtistsAsync(artistIds, token);
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
