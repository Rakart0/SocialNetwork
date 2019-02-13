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
        public static UserFollowViewModel ToUi(this User displayedUser, User currentlyLoggedUser)
        {
            return new UserFollowViewModel
            {
                UserName = displayedUser.UserName,
                userId = displayedUser.UserId,
                email = displayedUser.Email,

                isFollowedByLoggedUser = currentlyLoggedUser.Following.Select(x => x.FollowedId).Contains(displayedUser.UserId),
                isFollowingLoggedUser = displayedUser.Following.Select(x => x.FollowedId).Contains(currentlyLoggedUser.UserId)
                

            };
        }

        public static IEnumerable<UserFollowViewModel> ToUi(this IEnumerable<User> lst, User currentlyLoggedUser)
        {
            return lst.Select(u => u.ToUi(currentlyLoggedUser));
        }

    }
}
