using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Data.Models
{
    class FollowersFollowed
    {
        public int FollowerId { get; set; }
        public User Follower { get; set; }

        public int FollowedId { get; set; }
        public User Followed { get; set; }
    }
}
