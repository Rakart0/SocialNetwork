using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Data.Models
{
    public class GroupUser
    {
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
