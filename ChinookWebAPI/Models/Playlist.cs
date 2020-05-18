using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChinookWebAPI.Models
{
    public class Playlist
    {
        public string PlaylistName { get; set; }
        public int NumberOfTracks { get; set; }
    }

    public class PlaylistAndTracks
    {
        public string Playlist { get; set; }
        public int PlaylistId { get; set; }
        public IEnumerable<int> Tracks { get; set; }
    }

    public class Tracks
    {
        public int PlaylistId { get; set; }
        public int TrackId { get; set; }
    }
}
