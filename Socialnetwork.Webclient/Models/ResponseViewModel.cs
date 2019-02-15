using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Socialnetwork.Webclient.Models
{
    public class ResponseViewModel
    {
        public int PostId { get; set; }
        public string PostContent { get; set; }
        public string PostTime { get; set; }
        public int Likes { get; set; }
        public ResponseViewModel FirstResponse { get; set; }
        //public IEnumerable<string> TaggedGroups { get; set; }
        public string PosterId;
        public string PosterName;
    }
}
