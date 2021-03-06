﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Domain;
using System.Linq;
using Microsoft.EntityFrameworkCore.Design;
using Remotion.Linq.Clauses;

namespace server.Services
{
    public class MusicService : IMusicService
    {
        private readonly DataContext _dataContext;

        public MusicService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<Music>> GetMusicAsync()
        {
            return await _dataContext.Music.ToListAsync();
        }
        public async Task<bool> CreateMusicAsync(Music music)
        {
            await _dataContext.Music.AddAsync(music);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }
        public async Task<Music> GetMusicByIdAsync(Guid musicId)
        {
            return await _dataContext.Music.SingleOrDefaultAsync(x => x.MusicId == musicId);
        }

        public async Task<bool> UpdateMusicAsync(Music musicToUpdate)
        {
            _dataContext.Music.Update(musicToUpdate);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<bool> DeleteMusicAsync(Guid musicId)
        {
            var music = await GetMusicByIdAsync(musicId);
            _dataContext.Remove(music);
            var deleted = await _dataContext.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<List<Music>> GetMusicByPlaylistId(Guid playlistId)
        {
            var query = await (from a in _dataContext.UserPlayList
                from b in _dataContext.Music
                where a.PlaylistId == playlistId && a.MusicId == b.MusicId
                select b).ToListAsync();

            return query;
        }

        public async Task<List<Music>> GetMusicByUserId(string username)
        {
            var query = await _dataContext.Music.Where(x => x.UserName == username).ToListAsync();

            return query;
        }
    }
}
