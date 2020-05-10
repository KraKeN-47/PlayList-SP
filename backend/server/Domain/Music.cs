using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.Domain
{
    public class Music
    {
        [Key]
        public Guid Music_ID { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string Path { get; set; }
    }
}
