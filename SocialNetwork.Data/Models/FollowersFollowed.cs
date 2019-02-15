using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Data.Models
{
    public class FollowersFollowed
    {
        public string FollowerId { get; set; }
        public virtual User Follower { get; set; }

        public string FollowedId { get; set; }
        public virtual User Followed { get; set; }
    }
}
