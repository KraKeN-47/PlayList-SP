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
        public Guid PlayList_Id { get; set; }
        public string User_ID { get; set; }

        [ForeignKey(nameof(User_ID))]
        public User User { get; set; }

        public string Title { get; set; }
        public bool IsPrivate { get; set; }
        public string Desc { get; set; }


    }
}
