﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Contracts.V1;
using server.Contracts.V1.Requests;
using server.Contracts.V1.Responses;
using server.Domain;
using server.Extensions;
using server.Services;

namespace server.Controllers.V1
{
    public class MusicController : Controller
    {
        private readonly IMusicService _musicService;

        public MusicController(IMusicService musicService)
        {
            _musicService = musicService;
        }

        [HttpPost(ApiRoutes.Music.Create)]
        public async Task<IActionResult> UploadFile(UploadMusicRequest request)
        {
            if (request.File == null || !request.File.ContentType.Equals("audio/mpeg"))
            {
                return BadRequest(new { message = "File has an incorrect type, please try again!" });
            }

            var path = Path.GetFullPath("../../frontend/assets");
            var upload = Path.Combine(path);
            var id = Guid.NewGuid();
            using (var fs = new FileStream(Path.Combine(path, $"{id}.mp3"), FileMode.Create))
            {
                await request.File.CopyToAsync(fs);
            }

            var music = new Music()
            {
                MusicId = id,
                Title = request.Title,
                Desc = request.Description,
                Path = $"{path}\\{id.ToString()}.mp3",
                UserName = request.UserName
                //UserId = request.UserId
            };

            await _musicService.CreateMusicAsync(music);

            return Ok(new UploadMusicResponse(){Message = "Success"});
        }

        [HttpGet(ApiRoutes.Music.GetAll)]
        public async Task<IActionResult> GetAllMusic()
        {
            List<Music> allMusicList = await _musicService.GetMusicAsync();
            return Ok(new { musicList = allMusicList });
        }

        [HttpGet(ApiRoutes.Music.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid musicId)
        {
            var music = await _musicService.GetMusicByIdAsync(musicId);

            if (music == null)
                return NotFound();

            return Ok(music);
        }

        [HttpPut(ApiRoutes.Music.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid musicId, [FromBody] UpdateMusicRequest request)
        {
            var music = await _musicService.GetMusicByIdAsync(musicId);
            music.Title = request.Title;
            music.Desc = request.Desc;

            var updated = await _musicService.UpdateMusicAsync(music);

            if (updated)
                return Ok(music);

            return NotFound();
        }

        [HttpDeleteAttribute(ApiRoutes.Music.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid musicId)
        {
            var deleted = await _musicService.DeleteMusicAsync(musicId);

            if (deleted)
                return NoContent();

            return NotFound();
        }

        [HttpGet(ApiRoutes.Music.GetByPlaylistId)]
        public async Task<IActionResult> GetByPlaylistId([FromRoute] Guid playlistId)
        {
            List<Music> playlistMusicList = await _musicService.GetMusicByPlaylistId(playlistId);
            return Ok(new { musicList = playlistMusicList });
        }

        [HttpGet(ApiRoutes.Music.GetByUserId)]
        public async Task<IActionResult> Get(string username)
        {
            var music = await _musicService.GetMusicByUserId(username);
            return Ok(new { musicList = music });
        }
    }
}
