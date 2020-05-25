using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Domain;

namespace server.Services
{
    interface IPlaylistService
    {
        Task<List<PlayList>> GetPlaylistsAsync();
        Task<bool> CreatePlaylistAsync(PlayList playlist);
        Task<Music> GetPlaylistByIdAsync(Guid playlistId);
        Task<bool> UpdatePlaylistAsync(Music musicToUpdate);
        Task<bool> DeletePlaylistAsync(Guid palylistId);
    }
}
