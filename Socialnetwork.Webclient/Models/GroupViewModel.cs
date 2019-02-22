using SocialNetwork.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Socialnetwork.Webclient.Models
    {
    public class GroupViewModel
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public string AdminName { get; set; }
    }
}
