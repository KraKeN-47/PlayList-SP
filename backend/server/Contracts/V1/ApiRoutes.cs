using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Posts
        {
            public const string GetAll = Base + "/posts";
            public const string Update = Base + "/posts/{postId}";
            public const string Delete = Base + "/posts/{postId}";
            public const string Get = Base + "/posts/{postId}";
            public const string Create = Base + "/posts";
        }

        public static class Identity
        {
            public const string Login = Base + "/identity/login";
            public const string Register = Base + "/identity/register";
            public const string UserData = Base + "/identity/UserData";
            public const string GetAllArtists = Base + "/identity/artists";
        }

        public static class Music
        {
            public const string GetAll = Base + "/music";
            public const string Create = Base + "/music";
            public const string Get = Base + "/music/{musicId}";
            public const string Update = Base + "/music/{musicId}";
            public const string Delete = Base + "/music/{musicId}";
            public const string GetByPlaylistId = Base + "/music/playlists/{playlistId}";
            public const string GetByUserId = Base + "/music/users";

        }
        public static class Playlist
        {
            public const string GetAll = Base + "/playlist";
            public const string Create = Base + "/playlist";
            public const string Get = Base + "/playlist/{playlistId}";
            public const string Update = Base + "/playlist/{playlistId}";
            public const string Delete = Base + "/playlist/{playlistId}";
            public const string GetByUserId = Base + "/playlist/users/{userId}";
            public const string AddMusicToPlaylist = Base + "/playlist/music";
            public const string DeleteFromPlaylist = Base + "/playlist/music/delete";
        }

    }
}
