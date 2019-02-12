using Socialnetwork.Webclient.Models;
using SocialNetwork.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Socialnetwork.Webclient.Controllers.Converters
{
    public static class UserDataToUi
    {
        public static UserFollowViewModel ToUi(this User u)
        {
            return new UserFollowViewModel
            {
                name = u.UserName,
                userId = u.UserId
            };
        }

    }
}
