using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Data.Models
{
    public class HashtagPost
    {

        public int PostId { get; set; }
        public virtual Post Post { get; set; }
        public int HashtagId { get; set; }
        public virtual Hashtag Hashtag { get; set; }
    }
}
