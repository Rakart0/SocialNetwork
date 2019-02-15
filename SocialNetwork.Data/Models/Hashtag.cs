using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Data.Models
{
    public class Hashtag
    {
        public int HashtagId { get; set; }
        public string HashtagName { get; set; }
        public virtual IEnumerable<HashtagPost> Posts { get; set; }
    }
}
