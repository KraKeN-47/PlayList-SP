using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Domain;

namespace server.Services
{
    public interface IPlaylistService
    {
        Task<List<PlayList>> GetPlaylistsAsync();
        Task<bool> CreatePlaylistAsync(PlayList playlist);
        Task<PlayList> GetPlaylistByIdAsync(Guid playlistId);
        Task<bool> UpdatePlaylistAsync(PlayList playlistToUpdate);
        Task<bool> DeletePlaylistAsync(Guid playlistId);
    }
}
