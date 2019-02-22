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
        public static ThumbnailPostViewModel ToThumbnail(this Post p)
        {
            ThumbnailPostViewModel tpvm = new ThumbnailPostViewModel();
            tpvm.PostId = p.PostId;
            tpvm.PostContent = p.PostContent;
            tpvm.PostTime = p.PostTime.ToShortDateString();
            tpvm.Likes = p.Likes.Where(l => l.Like == true).Count() - p.Likes.Where(l => l.Like == false).Count();
            tpvm.PosterId = p.Poster.UserId;
            tpvm.PosterName = p.Poster.UserName;
            if(p.Images != null)
            {
                List<string> images = new List<string>();
                foreach (var item in p.Images)
                {
                    images.Add(item.Url);
                }
                tpvm.Images = images;
            }
            //pvm.TaggedGroups = p.TaggedGroups.Select(tg => tg.Group.GroupName);

            return tpvm;
        }

        public static IEnumerable<ThumbnailPostViewModel> ToThumbnail(this IEnumerable<Post> lstP)
        {
            return lstP.Select(p => p.ToThumbnail());
        }

        public static PostViewModel ToPostViewModel(this Post p)
        {
            PostViewModel pvm = new PostViewModel();
            pvm.PostId = p.PostId;
            pvm.PostContent = p.PostContent;
            pvm.PostTime = p.PostTime.ToShortDateString();
            pvm.Likes = p.Likes.Where(l => l.Like == true).Count() - p.Likes.Where(l => l.Like == false).Count();
            pvm.PosterId = p.Poster.UserId;
            pvm.PosterName = p.Poster.UserName;
            List<ResponseViewModel> responses = new List<ResponseViewModel>();
            ResponseViewModel resPvm;
            foreach (var item in p.Responses)
            {
                resPvm = item.ToResponseViewModel();
                resPvm.FirstResponse = item.Responses.FirstOrDefault().ToResponseViewModel();

                responses.Add(resPvm);
            }
            pvm.Responses = responses;
            //pvm.TaggedGroups = p.TaggedGroups.Select(tg => tg.Group.GroupName);

            return pvm;
        }
        public static IEnumerable<PostViewModel> ToPostViewModel(this IEnumerable<Post> lstP)
        {
            return lstP.Select(p => p.ToPostViewModel());
        }
        public static ReplyViewModel ToReplyViewModel(this Post p)
        {
            return new ReplyViewModel
            {
                InResponseToId = p.PostId,
                PostContent = p.PostContent
            };
        }
        public static ResponseViewModel ToResponseViewModel(this Post p)
        {
            if(p != null)
            {
                return new ResponseViewModel
                {
                    PostId = p.PostId,
                    PostContent = p.PostContent,
                    PostTime = p.PostTime.ToShortDateString(),
                    Likes = p.Likes.Where(l => l.Like == true).Count() - p.Likes.Where(l => l.Like == false).Count(),
                    PosterId = p.Poster.UserId,
                    PosterName = p.Poster.UserName,
                };
            }
            else
            {
                return null;
            }
        }
        public static CreateEditPostViewModel ToEditViewModel(this Post p)
        {
            return new CreateEditPostViewModel
            {
                PostContent = p.PostContent
            };
        }
    }
}
