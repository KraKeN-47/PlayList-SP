using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using server.Contracts.V1.Requests;
using server.Contracts.V1.Responses;
using server.Data;
using server.Domain;

namespace server.Services
{
    public class UploadService : IUploadService
    {
        private readonly DataContext _dataContext;

        public UploadService(DataContext dataContext)
        {
            _dataContext = dataContext;
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
        public async Task<bool> DeleteMusicAsync(Guid musicId)
        {
            var music = await GetMusicByIdAsync(musicId);
            _dataContext.Remove(music);
            var deleted = await _dataContext.SaveChangesAsync();
            return deleted > 0;
        }
        public async Task<List<Music>> GetAllMusicAsync()
        {
            List<Music> failed;
            try
            {
                failed = await _dataContext.Music.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return failed;
        }
    }
}
