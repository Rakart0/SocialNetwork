using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Socialnetwork.Webclient.Models
{
    public class UserFollowViewModel
    {
        [DisplayName("User name")]
        public string UserName;

        public string userId;

        [DisplayName("User email")]
        public string email;
        
        //Todo
        public bool isFollowedByLoggedUser;
        public bool isFollowingLoggedUser;
    }
}
