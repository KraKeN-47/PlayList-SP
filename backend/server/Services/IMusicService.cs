using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using server.Contracts.V1.Requests;
using server.Contracts.V1.Responses;
using server.Domain;

namespace server.Services
{
    public interface IMusicService
    {
        Task<List<Music>> GetMusicAsync();
        Task<bool> CreateMusicAsync(Music music);
        Task<Music> GetMusicByIdAsync(Guid musicId);
        Task<bool> UpdateMusicAsync(Music musicToUpdate);
        Task<bool> DeleteMusicAsync(Guid musicId);
        Task<List<Music>> GetMusicByPlaylistId(Guid playlistId);
        Task<List<Music>> GetMusicByUserId(string username);
    }
}
