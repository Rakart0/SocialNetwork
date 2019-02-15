using Socialnetwork.Webclient.Models;
using SocialNetwork.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Socialnetwork.Webclient.Controllers.Converters
    {
    public static class GroupPostDataToUI
        {
        public static GroupPostViewModel ToUI(this GroupPost gp)
            {
            GroupPostViewModel gpvm = new GroupPostViewModel();
            gpvm.GPostId = gp.PostId;
            gpvm.GPost = gp.Post;
            gpvm.Group = gp.Group;
            gpvm.GroupId = gp.GroupId;

            return gpvm;

            }
        public static IEnumerable<GroupPostViewModel> ToUI(this IEnumerable<GroupPost> lstGP)
            {
            return lstGP.Select(gp => gp.ToUI());
            }
        }
    }
