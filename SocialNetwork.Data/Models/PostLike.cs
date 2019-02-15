﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Data.Models
{
    public class PostLike
    {
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
        public bool Like { get; set; }
    }
}
