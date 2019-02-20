using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Socialnetwork.Webclient.Models
{
    public class DashboardPostViewModel
    {

        public int PostId { get; set; }
        public string PostContent { get; set; }
        public string PostTime { get; set; }
        public int Likes { get; set; }
        public string PosterName { get; set; }
        public string PosterImageUrl { get; set; }
        public bool IsFollowed { get; set; }



    }
}
