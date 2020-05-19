using System;

namespace server.Contracts.V1.Responses
{
    public class UserResponse
    {
        public string Email { get; set; }
        public bool IsArtist { get; set; }
        public string UserName { get; set; }
        public Guid Id { get; set; }
    }
}
