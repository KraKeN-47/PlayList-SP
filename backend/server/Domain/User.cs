﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace server.Domain
{
    public class User : IdentityUser
    {
        public bool IsArtist { get; set; }

        public ICollection<PlayList> Playlists { get; set; }

    }
}
