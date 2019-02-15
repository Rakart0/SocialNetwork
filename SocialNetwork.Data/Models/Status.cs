using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SocialNetwork.Data.Models
{
    [Table("Status")]
    public class Status
    {
        [Key]
        public int StatusID { get; set; }
        
        [Required]
        [MaxLength]
        public string StatusContent { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime StatusPostDate { get; set; }

        public bool Edited { get; set; }

    }
}
