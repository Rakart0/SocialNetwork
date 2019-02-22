using Socialnetwork.Webclient.Models;
using SocialNetwork.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Socialnetwork.Webclient.Controllers.Converters
{
    public static class SearchDataToUi
    {
        public static SearchViewModel ToSearchViewModel(this User u)
        {
            return new SearchViewModel
            {
                value = "U" + u.UserId,
                label = u.UserName
            };
        }
        public static SearchViewModel ToSearchViewModel(this Group g)
        {
            return new SearchViewModel
            {
                value = "G" + g.GroupeId,
                label = g.GroupName
            };
        }
        public static SearchViewModel ToSearchViewModel(this Hashtag h)
        {
            return new SearchViewModel
            {
                value = "H" + h.HashtagId,
                label = h.HashtagName
            };
        }
        public static IEnumerable<SearchViewModel> ToSearchViewModel(this IEnumerable<User> lstU)
        {
            return lstU.Select(u => u.ToSearchViewModel());
        }
        public static IEnumerable<SearchViewModel> ToSearchViewModel(this IEnumerable<Group> lstG)
        {
            return lstG.Select(g => g.ToSearchViewModel());
        }
        public static IEnumerable<SearchViewModel> ToSearchViewModel(this IEnumerable<Hashtag> lstH)
        {
            return lstH.Select(h => h.ToSearchViewModel());
        }
    }
}
