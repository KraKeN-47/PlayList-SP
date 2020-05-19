using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace server.Contracts.V1.Requests
{
    public class UploadMusicRequest
    {
        public string Title { get; set; }
        public string  Description { get; set; }
        [FromForm(Name = "file")]
        public IFormFile File { get; set; }

        public string UserName { get; set; }
    }
}
