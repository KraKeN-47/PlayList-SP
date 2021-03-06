﻿using System.ComponentModel.DataAnnotations;

namespace server.Contracts.V1.Requests
{
    public class UserRegistrationRequest
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsArtist { get; set; }
        public string UserName { get; set; }
    }
}