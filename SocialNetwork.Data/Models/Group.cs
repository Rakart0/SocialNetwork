using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SocialNetwork.Data.Models
{
    [Table("Group")]
    class Group
    {
        [Key]
        public int GroupeId { get; set; }
        [Required]
        [StringLength(50, MinimumLength =3)]
        public string GroupName { get; set; }
        public IEnumerable<GroupPost>  Posts {get; set;}
        //public int AdminId { get; set; }
        //[Required]
        //[ForeignKey("UserId")]
        public User Admin { get; set; }
        public IEnumerable<User> Moderators { get; set; }
        public Post AnnouncedPost { get; set; }


    }
}
