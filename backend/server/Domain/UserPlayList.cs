using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.OAuth;

namespace server.Domain
{
    public class UserPlayList
    {
        [Key]
        public Guid UserPlaylist { get; set; }

        public Guid PlaylistId { get; set; }
        public PlayList PlayList { get; set; }

        public Guid MusicId { get; set; }
        public Music Music { get; set; }
    }
}
