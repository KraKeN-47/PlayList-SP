using System;
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
using server.Services;

namespace server.Controllers.V1
{
    public class UploadController : Controller
    {
        private readonly IUploadService _uploadService;

        public UploadController(IUploadService uploadService)
        {
            _uploadService = uploadService;
        }

        [HttpPost(ApiRoutes.MusicFile.Upload)]
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
                Path = $"{path}/{id.ToString()}.mp3",
                UserName = request.UserName
                //UserId = request.UserId
            };

            await _uploadService.CreateMusicAsync(music);

            return Ok(new UploadMusicResponse(){Message = "Success"});
        }
        [HttpGet(ApiRoutes.MusicFile.GetAllMusic)]
        public async Task<IActionResult> GetAllMusic()
        {
            List<Music> allMusicList = await _uploadService.GetAllMusicAsync();
            return Ok(new { musicList = allMusicList });
        }
        [HttpGet(ApiRoutes.MusicFile.GetMusicById)]
        public async Task<IActionResult> GetMusicById()
        {
            List<Music> allMusic = await _uploadService.GetAllMusicAsync();
            //await _uploadService.DeleteMusicAsync(Guid.Parse("1AF58D49-42B4-4060-94F2-6DDB1E27D7CE"));
            return Ok(new { musicObj = allMusic });
        }
    }
}
