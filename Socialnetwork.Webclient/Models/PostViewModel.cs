using SocialNetwork.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Socialnetwork.Webclient.Models
{
    public class OriginalPostViewModel
    {
        public OriginalPostViewModel()
        {

        }
        public OriginalPostViewModel(string postContent)
        {

        }
        public int PostId { get; set; }
        public string PostContent { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime PostTime { get; set; }
        public int Likes { get; set; }
        public IEnumerable<string> TaggedGroups { get; set; }
        public string PosterId;
        public string PosterName;
    }
}
