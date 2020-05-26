using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
    public class IdentityController : Controller
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost(ApiRoutes.Identity.Register)]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))
                });
            }

            var authResponse = await _identityService.RegisterAsync(request);

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResponse.Errors
                });
            }

            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token
            });
        }

        [HttpPost(ApiRoutes.Identity.Login)]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            var authResponse = await _identityService.LoginAsync(request.Username, request.Password);

            if (!authResponse.Success)
            {
                return BadRequest(new
                {
                    data = new AuthFailedResponse
                    {
                        Errors = authResponse.Errors
                    }
                });
            }

            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token,
            });
        }
        [HttpGet(ApiRoutes.Identity.UserData)]
        public async Task<IActionResult> UserData()
        {
            var handler = new JwtSecurityTokenHandler();
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var readToken = handler.ReadJwtToken(token);
            var userName = readToken.Subject;
            var userId = readToken.Claims.Where(claim => claim.Type == "id").Select(Type => Type.Value).SingleOrDefault();
            var email = readToken.Claims.Where(claim => claim.Type == "email").Select(Type => Type.Value).SingleOrDefault();
            var isArtist = readToken.Claims.Where(claim => claim.Type == "isArtist").Select(Type => Type.Value).SingleOrDefault();
            return Ok( new { user = new UserResponse { Email = email.ToString(), UserName = userName , IsArtist = bool.Parse(isArtist.ToString()), Id = Guid.Parse(userId) } });
        }

        [HttpGet(ApiRoutes.Identity.GetAllArtists)]
        public async Task<IActionResult> GetAllMusic()
        {
            List<User> allArtists = await _identityService.GetAllArtists();
            return Ok(new { artistsList = allArtists });
        }
    }
}