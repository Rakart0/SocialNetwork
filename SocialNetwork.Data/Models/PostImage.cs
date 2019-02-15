using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SocialNetwork.Data.Models
{
    [Table("PostImage")]
    public class PostImage
    {
        public string Url { get; set; }
        public virtual Post Post { get; set; }
        public int PostId { get; set; }
    }
}
