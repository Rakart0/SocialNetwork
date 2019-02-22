using Socialnetwork.Webclient.Models;
using SocialNetwork.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Socialnetwork.Webclient.Controllers.Converters
{
    public static class GroupDataToUI
    {
        public static GroupViewModel ToUI(this Group g)
        {
            return new GroupViewModel
            {
                GroupId = g.GroupeId,
                GroupName = g.GroupName,
                GroupDescription = g.Description,
                AdminName = g.Admin.UserName
            };
        }
        public static IEnumerable<GroupViewModel> ToUI(this IEnumerable<Group> lstG)
        {
            return lstG.Select(gp => gp.ToUI());
        }
        public static Group ToData(this GroupViewModel model)
        {
            return new Group
            {
                GroupeId = model.GroupId,
                GroupName = model.GroupName,
                Description = model.GroupDescription,
            };
        }
    }

}
