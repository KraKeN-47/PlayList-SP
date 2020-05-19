using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace server.Domain
{
    public class PlayList
    {
        [Key]
        public Guid PlaylistId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public bool IsPrivate { get; set; }
        public string Desc { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public ICollection<UserPlayList> UserPlayLists { get; set; }
    }
}
