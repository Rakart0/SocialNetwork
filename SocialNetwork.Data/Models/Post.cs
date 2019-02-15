using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SocialNetwork.Data.Models
{
    [Table("Post")]
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        //[MaxLength]
        public string PostContent { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime PostTime { get; set; }
        public virtual IEnumerable<HashtagPost> Hashtag { get; set; }
        public virtual IEnumerable<PostLike> Likes { get; set; }
        public virtual IEnumerable<TaggedUserPost> TaggedPeople { get; set; }
        public virtual IEnumerable<GroupPost> TaggedGroups { get; set; }
        public virtual IEnumerable<Post> Responses { get; set; }
        public bool IsOriginalPost { get; set; }
        public virtual Post OriginalPost { get; set; }
        public virtual Post InResponseTo { get; set; }
        public virtual User Poster { get; set; }
        public virtual IEnumerable<PostImage> Images{ get; set;}
    }
}
