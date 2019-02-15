using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Socialnetwork.Webclient.Models
{
    public class PostViewModel
    {
        public int PostId { get; set; }
        public string PostContent { get; set; }
        public string PostTime { get; set; }
        public int Likes { get; set; }
        public IEnumerable<ResponseViewModel> Responses { get; set; }
        //public IEnumerable<string> TaggedGroups { get; set; }
        public string PosterId;
        public string PosterName;
    }
}
