using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
