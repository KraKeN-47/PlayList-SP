using Microsoft.AspNetCore.Identity;
using server.Contracts.V1.Requests;
using server.Controllers.V1;
using server.Domain;
using System;
using server.Services;
using server.Controllers.V1;
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

            //var okResult = result.Should().

            Assert.NotNull(result);
            //rezultato.status ,ar tokenas geras
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

            Assert.NotNull(result);
        }
    }
}
