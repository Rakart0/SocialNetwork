using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SocialNetwork.Data.Models
{
    [Table("Post")]
    class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        [MaxLength]
        public string PostContent { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime PostTime { get; set; }
        public IEnumerable<HashtagPost> Hashtag { get; set; }
        public IEnumerable<PostLike> Likes { get; set; }
        public IEnumerable<TaggedUserPost> TaggedPeople { get; set; }
        public IEnumerable<GroupPost> TaggedGroups { get; set; }
        public IEnumerable<Post> Responses { get; set; }
        public bool IsOriginalPost { get; set; }
        public Post OriginalPost { get; set; }
        public Post InResponseTo { get; set; }
        public User Poster { get; set; }
        //Todo
        //public string Image { get; set; }
    }
}
