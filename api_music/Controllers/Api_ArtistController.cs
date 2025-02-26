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
        private readonly ArtistService artistService;
        // xác minh access token 
        private readonly SpotifyAuthService spotifyAuthService;

        public Api_ArtistController()
        {
            artistService = new ArtistService();
            spotifyAuthService = new SpotifyAuthService();

        }
        // get api một nghệ sĩ theo id 
        [HttpGet("artist/{artistId}")]
        public async Task<IActionResult> GetArtist(string artistId)
        {
            var token = await spotifyAuthService.GetAccessTokenAsync();
            var artistData = await artistService.GetArtistAsync(artistId, token);
            return Ok(artistData);
        }

    }
}
