using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace server.Domain
{
    public class UserPlayList
    {
        [Key]
        public Guid User_PlayList_ID { get; set; }
        public Guid Playlist_ID { get; set; }
        public Guid Music_ID { get; set; }

        [ForeignKey(nameof(Playlist_ID))]
        public PlayList PlayList { get; set; }
        [ForeignKey(nameof(Music_ID))]
        public Music Music { get; set; }
    }
}
