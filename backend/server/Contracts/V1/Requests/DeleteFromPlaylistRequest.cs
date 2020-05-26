using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Contracts.V1.Requests
{
    public class DeleteFromPlaylistRequest
    {
        public Guid PlaylistId { get; set; }
        public Guid MusicId { get; set; }
    }
}
