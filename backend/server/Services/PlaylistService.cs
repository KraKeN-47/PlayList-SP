using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Domain;

namespace server.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly DataContext _dataContext;
        public PlaylistService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<PlayList>> GetPlaylistsAsync()
        {
            return await _dataContext.PlayList.ToListAsync();
        }

        public async Task<bool> CreatePlaylistAsync(PlayList playlist)
        {
            await _dataContext.PlayList.AddAsync(playlist);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<Music> GetPlaylistByIdAsync(Guid playlistId)
        {
            return await _dataContext.Music.SingleOrDefaultAsync(x => x.MusicId == playlistId);
        }

        public Task<bool> UpdatePlaylistAsync(Music musicToUpdate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePlaylistAsync(Guid palylistId)
        {
            throw new NotImplementedException();
        }
    }
}
