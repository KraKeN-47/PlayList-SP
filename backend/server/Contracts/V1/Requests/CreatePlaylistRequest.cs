using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Contracts.V1.Requests
{
    public class CreatePlaylistRequest
    {
        public string UserId { get; set; }
        public string Title { get; set; }
        public bool IsPrivate { get; set; }
        public string Desc { get; set; }
    }
}
