using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChinookWebAPI.DataAccess;
using ChinookWebAPI.Models;
using Microsoft.Data.SqlClient;
using Dapper;

namespace ChinookWebAPI.DataAccess
{
    public class PlaylistRepository
    {
        const string ConnectionString = "Server = localhost; Database = Chinook; Trusted_Connection = True;";
        public List<Playlist> GetPlaylistAndTracks()
        {
            var sql = @"select Playlist.Name as PlaylistName, Count(*) NumberOfTracks
                        from Playlist
	                        join PlaylistTrack
		                        on Playlist.PlaylistId = PlaylistTrack.PlaylistId
			                        group by Playlist.Name";

            using (var db = new SqlConnection(ConnectionString))
            {
                var playlists = db.Query<Playlist>(sql).ToList();
                return playlists;
            }
        }
    }
}
