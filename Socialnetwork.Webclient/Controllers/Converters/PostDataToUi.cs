using Socialnetwork.Webclient.Models;
using SocialNetwork.Data.Models;
using SocialNetwork.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Socialnetwork.Webclient.Controllers.Converters
{
    public static class PostDataToUi
    {
        public static OriginalPostViewModel ToUi(this Post p)
        {
            OriginalPostViewModel pvm = new OriginalPostViewModel();
            pvm.PostId = p.PostId;
            pvm.PostContent = p.PostContent;
            pvm.PostTime = p.PostTime;
            pvm.Likes = 0;
            //pvm.PosterId = p.Poster.UserId;
            //pvm.PosterName = p.Poster.UserName;
            //pvm.TaggedGroups = p.TaggedGroups.Select(tg => tg.Group.GroupName);

            return pvm;
        }

        public static IEnumerable<OriginalPostViewModel> ToUi(this IEnumerable<Post> lstP)
        {
            return lstP.Select(p => p.ToUi());
        }

    }
}
