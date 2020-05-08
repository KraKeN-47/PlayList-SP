using System.Collections.Generic;

namespace server.Domain
{
    public class AuthenticationResult
    {
        public string Token { get; set; }
        public bool Success { get; set; }
        public string Email { get; set; }
        public bool IsArtist { get; set; }
        public string UserName { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}