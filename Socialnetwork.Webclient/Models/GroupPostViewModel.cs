using SocialNetwork.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Socialnetwork.Webclient.Models
    {
    public class GroupPostViewModel
        {
        public GroupPostViewModel()
            {

            }
        public GroupPostViewModel( string postContent)
            {

            }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public int GPostId { get; set; }
        public Post GPost { get; set; }
        }
    }
