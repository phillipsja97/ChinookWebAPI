using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChinookWebAPI.DataAccess;

namespace ChinookWebAPI.Controllers
{
    [Route("api/playlists")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        // -- playlists_track_count.sql: Provide a query that shows the total number of tracks in each playlist. 
        // The Playlist name should be include on the resultant table.
        [HttpGet]
        public IActionResult GetPlaylistAndTracks()
        {
            var repo = new PlaylistRepository();
            var playlists = repo.GetPlaylistAndTracks();
            return Ok(playlists);
        }

        [HttpGet("tracks")]
        public IActionResult GetTheTracksInPlaylist()
        {
            var repo = new PlaylistRepository();
            var playlist = repo.GetTheTracksInPlaylist();
            return Ok(playlist);
        }
    }
}
