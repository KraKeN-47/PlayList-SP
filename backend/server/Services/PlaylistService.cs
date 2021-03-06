﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;
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

        public async Task<PlayList> GetPlaylistByIdAsync(Guid playlistId)
        {
            return await _dataContext.PlayList.SingleOrDefaultAsync(x => x.PlaylistId == playlistId);
        }

        public async Task<bool> UpdatePlaylistAsync(PlayList playlistToUpload)
        {
            _dataContext.PlayList.Update(playlistToUpload);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<bool> DeletePlaylistAsync(Guid playlistId)
        {
            var playlist = await GetPlaylistByIdAsync(playlistId);
            _dataContext.RemoveRange(_dataContext.UserPlayList.Where(x => x.PlaylistId == playlistId));
            _dataContext.Remove(playlist);
            var deleted = await _dataContext.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<List<PlayList>> GetPlaylistsByUserId(Guid userId)
        {
            return await _dataContext.PlayList.Where(a => a.UserId == userId.ToString()).ToListAsync();
        }

        public async Task<bool> AddMusicToPlaylist(UserPlayList record)
        {
            var exist = await _dataContext.UserPlayList
                .Where(x => x.PlaylistId == record.PlaylistId && x.MusicId == record.MusicId)
                .SingleOrDefaultAsync();
            if (exist == null)
            {
                await _dataContext.UserPlayList.AddAsync(record);
                var created = await _dataContext.SaveChangesAsync();
                return created > 0;
            }

            return false;
        }

        public async Task<bool> DeleteMusicFromPlaylistAsync(UserPlayList record)
        {
            _dataContext.RemoveRange(_dataContext.UserPlayList.Where(x => x.PlaylistId == record.PlaylistId && x.MusicId == record.MusicId));
            var deleted = await _dataContext.SaveChangesAsync();
            return deleted > 0;
        }
    }
}
