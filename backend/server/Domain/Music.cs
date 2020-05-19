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
        public Guid MusicId { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string Path { get; set; }

        public string UserName { get; set; }
        public User User { get; set; }

        public ICollection<UserPlayList> UserPlayLists { get; set; }
    }
}
