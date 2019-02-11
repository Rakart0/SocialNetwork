using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Data.Models
{
    public class PostLike
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public bool Like { get; set; }
    }
}
