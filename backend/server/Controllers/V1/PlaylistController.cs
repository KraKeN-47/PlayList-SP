﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Contracts.V1;
using server.Contracts.V1.Requests;
using server.Contracts.V1.Responses;
using server.Domain;
using server.Services;

namespace server.Controllers.V1
{
    public class PlaylistController : Controller
    {
        private readonly IPlaylistService _playlistService;

        public PlaylistController(IPlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        [HttpGet(ApiRoutes.Playlist.GetAll)]
        public async Task<IActionResult> GetAllPlaylists()
        {
            List<PlayList> allPlaylists = await _playlistService.GetPlaylistsAsync();
            return Ok(new { playlists = allPlaylists });
        }

        [HttpGet(ApiRoutes.Playlist.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid playlistId)
        {
            var playlist = await _playlistService.GetPlaylistByIdAsync(playlistId);

            if (playlist == null)
                return NotFound();

            return Ok(playlist);
        }

        [HttpPost(ApiRoutes.Playlist.Create)]
        public async Task<IActionResult> UploadFile([FromBody]CreatePlaylistRequest request)
        {
            var playlist = new PlayList()
            {
                UserId = request.UserId,
                Title = request.Title,
                IsPrivate = request.IsPrivate,
                Desc = request.Desc
            };

            await _playlistService.CreatePlaylistAsync(playlist);

            return Ok(new PlaylistCreatedResponse() { Message = "Success" });
        }

        [HttpPut(ApiRoutes.Playlist.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid playlistId, [FromBody] UpdatePlaylistRequest request)
        {

            var playlist = await _playlistService.GetPlaylistByIdAsync(playlistId);
            playlist.Title = request.Title;
            playlist.IsPrivate = request.IsPrivate;
            playlist.Desc = request.Desc;

            var updated = await _playlistService.UpdatePlaylistAsync(playlist);

            if (updated)
                return Ok(playlist);

            return NotFound();
        }

        [HttpDeleteAttribute(ApiRoutes.Playlist.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid playlistId)
        {
            var deleted = await _playlistService.DeletePlaylistAsync(playlistId);

            if (deleted)
                return NoContent();

            return NotFound();
        }

        [HttpGet(ApiRoutes.Playlist.GetByUserId)]
        public async Task<IActionResult> GetAllByUserId([FromRoute] Guid userId)
        {
            List<PlayList> allPlaylists = await _playlistService.GetPlaylistsByUserId(userId);
            return Ok(new { playlists = allPlaylists });
        }

        [HttpPost(ApiRoutes.Playlist.AddMusicToPlaylist)]
        public async Task<IActionResult> AddMusicToPlaylist([FromBody]AddMusicToPlaylistRequest request)
        {
            var record = new UserPlayList()
            {
                PlaylistId = request.PlaylistId,
                MusicId = request.MusicId
            };

            await _playlistService.AddMusicToPlaylist(record);

            return Ok(new AddedToPlaylistResponse() { Message = "Success" });
        }

        [HttpPost(ApiRoutes.Playlist.DeleteFromPlaylist)]
        public async Task<IActionResult> DeleteFromPlaylist([FromBody]DeleteFromPlaylistRequest request)
        {
            var record = new UserPlayList()
            {
                PlaylistId = Guid.Parse(request.PlaylistId),
                MusicId = Guid.Parse(request.MusicId)
            };
            var deleted = await _playlistService.DeleteMusicFromPlaylistAsync(record);

            if (deleted)
                return NoContent();

            return NotFound();
        }

    }
}
