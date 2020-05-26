using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Contracts.V1.Requests
{
    public class DeleteFromPlaylistRequest
    {
        public string PlaylistId { get; set; }
        public string MusicId { get; set; }
    }
}
