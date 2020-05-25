using Microsoft.AspNetCore.Identity;
using server.Contracts.V1.Requests;
using server.Controllers.V1;
using server.Services;
using server.Domain;
using System;
using Xunit;
using server.Options;
using Moq;
using System.Threading;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using server.Contracts.V1.Responses;
using System.Web.Http.Results;
using System.IO;
using System.Text;

namespace XUnitTest
{
    public class UnitTest1
    {

        [Fact]
        public async Task Registration_Test()
        {
            var request = new UserRegistrationRequest();
            request.Email = "test1@gmail.com";
            request.IsArtist = true;
            request.Password = "test1";
            request.UserName = "test1";

            var mockUserStore = new Mock<IIdentityService>();

            mockUserStore.Setup(x => x.RegisterAsync(request)).Returns(Task.FromResult(new AuthenticationResult()
            {
                Email = "test1@gmail.com",
                IsArtist = true,
                UserName = "test1",
                Token = "123123",
                Success = true,
                Errors = null
            }));
            var controller = new IdentityController(mockUserStore.Object);

            //act
            var result = await controller.Register(request);
            
            var content = result as OkObjectResult;
            
            //var okResult = result.Should().

            Assert.NotNull(result);
            Assert.NotNull(content.Value);
            Assert.IsType<AuthSuccessResponse>(content.Value);
            Assert.Equal(StatusCodes.Status200OK, content.StatusCode);

        }
        [Fact]
        public async Task Login_Test()
        {
            var request = new UserLoginRequest();
            request.Username = "test1";
            request.Password = "test1";

            var mockUserStore = new Mock<IIdentityService>();

            mockUserStore.Setup(x => x.LoginAsync(request.Username, request.Password)).Returns(Task.FromResult(new AuthenticationResult()
            {
                Email = "test1@gmail.com",
                IsArtist = true,
                UserName = "test1",
                Token = "123123",
                Success = true,
                Errors = null
            }));

            var controller = new IdentityController(mockUserStore.Object);

            var result = await controller.Login(request);

            var content = result as OkObjectResult;

            Assert.NotNull(result);
            Assert.NotNull(content.Value);
            Assert.IsType<AuthSuccessResponse>(content.Value);
            Assert.Equal(StatusCodes.Status200OK, content.StatusCode);
        }
        [Fact]
        public async Task Upload_File_Test()
        {
            using (var stream = File.OpenRead(@"../../../../../frontend/assets/YES.mp3"))
            {
                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(@"../../../../../frontend/assets/YES.mp3"))
                {
                    Headers = new HeaderDictionary(),
                    //ContentType = "jpeg"
                    ContentType = "audio/mpeg"
                };
                var request = new UploadMusicRequest();

                request.File = file;
                request.Description = "test";
                request.UserName = "test";

                var mockUserStore = new Mock<IUploadService>();
                var music = new Music();
                var id = Guid.NewGuid();
                var path = Path.GetFullPath("../../../../../frontend/assets");
                //var path = Path.GetFullPath("../../frontend/assets");

                using (var fs = new FileStream(Path.Combine(path, $"{id}.mp3"), FileMode.Create))
                {
                    await request.File.CopyToAsync(fs);
                }

                music.MusicId = id;
                music.Title = request.Title;
                music.Desc = request.Description;
                music.UserName = request.UserName;
                music.Path = $"{path}\\{id.ToString()}.mp3";

                mockUserStore.Setup(x => x.CreateMusicAsync(music)).Returns(Task.FromResult(true));

                var controller = new UploadController(mockUserStore.Object);

                var result = await controller.UploadFile(request);


                var content = result as OkObjectResult;

                Assert.NotNull(result);
                Assert.NotNull(content.Value);
                Assert.IsType<UploadMusicResponse>(content.Value);
                Assert.Equal(StatusCodes.Status200OK, content.StatusCode);
            }
        }
    }
}