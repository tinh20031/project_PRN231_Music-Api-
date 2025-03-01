using api_music.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_music.Controllers
{
	[Route("api/spotify")]
	[ApiController]
	public class Api_PlaylistController : ControllerBase
	{
		private readonly PlaylistServices _playlistServices;

		// xác minh access token 
		private readonly SpotifyAuthService _spotifyAuthService;
		public Api_PlaylistController(PlaylistServices playlistServices, SpotifyAuthService spotifyAuthService)
		{
			_playlistServices = playlistServices ?? throw new ArgumentNullException(nameof(playlistServices));
			_spotifyAuthService = spotifyAuthService ?? throw new ArgumentNullException(nameof(spotifyAuthService));
		}


		//lấy 1 playlist 
		// hiện playlist chỉ lấy cho user tạo playlist 

		[HttpGet("playlist/{PlaylistId}")]
		public async Task<IActionResult> GetArtist(string PlaylistId)
		{
			var token = await _spotifyAuthService.GetAccessTokenAsync();
			var artistData = await _playlistServices.GetPlaylistAsync(PlaylistId, token);
			return Ok(artistData);
		}


	}
}
