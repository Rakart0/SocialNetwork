using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Socialnetwork.Webclient.Models;
using SocialNetwork.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Socialnetwork.Webclient.Helpers
{
    public interface IControllerHelper
    {
        string GetUserId(ClaimsPrincipal user);
        List<string> UploadImages(List<IFormFile> files, IHostingEnvironment hostingEnvironment, string fileFolder);
        string UploadImage(IFormFile file, IHostingEnvironment hostingEnvironment, string fileFolder);
        IActionResult Like(int postId);
        IActionResult Dislike(int postId);
        Post Reply(int inResponseToId, ReplyViewModel model, IHostingEnvironment hostingEnvironment);
        void EditPost(int postId, CreateEditPostViewModel model, IHostingEnvironment hostingEnvironment);
    }
}
