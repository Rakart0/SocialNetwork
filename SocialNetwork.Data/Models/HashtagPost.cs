using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Data.Models
{
    public class HashtagPost
    {

        public int PostId { get; set; }
        public Post Post { get; set; }
        public int HashtagId { get; set; }
        public Hashtag Hashtag { get; set; }
    }
}
