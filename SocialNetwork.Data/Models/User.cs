﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SocialNetwork.Data.Models
{
    [Table("User")]

    public class User
    {

        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        public IEnumerable<FollowersFollowed> Following { get; set; }
        public IEnumerable<FollowersFollowed> Followers { get; set; }

        public IEnumerable<Group> SubscribedGroups { get; set; }

        public IEnumerable<Post> Posts { get; set; }

        public IEnumerable<PostLike> LikedPosts { get; set; }
        public IEnumerable<TaggedUserPost> TaggedPosts { get; set; }

        [DataType(DataType.Url)]
        public string UserPictureUrl { get; set; }


        //A envisager plus tard :

        //public IEnumerable<Post> Posts { get; set; }
    }
}
