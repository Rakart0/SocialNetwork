using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Data.Models
{
    public class GroupPost
    {
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
