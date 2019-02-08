using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Data.Models
{
    class Hashtag
    {
        public int HashtagId { get; set; }
        public string HashtagName { get; set; }
        public IEnumerable<HashtagPost> Posts { get; set; }
    }
}
