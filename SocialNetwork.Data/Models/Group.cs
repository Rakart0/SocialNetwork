using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SocialNetwork.Data.Models
{
    [Table("Group")]
    public class Group
    {
        [Key]
        public int GroupeId { get; set; }
        [Required]
        [StringLength(50, MinimumLength =3)]
        public string GroupName { get; set; }
        public virtual IEnumerable<GroupPost>  Posts {get; set;}
        //public int AdminId { get; set; }
        //[Required]
        //[ForeignKey("UserId")]
        public virtual User Admin { get; set; }
        public virtual IEnumerable<User> Moderators { get; set; }
        public virtual Post AnnouncedPost { get; set; }


    }
}
