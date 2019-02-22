using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Data.Models;
using SocialNetwork.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Socialnetwork.Webclient.Models;

namespace Socialnetwork.Webclient.Helpers
{
    public class ControllerHelper : Controller, IControllerHelper
    {
        private IRepoPost repoP;
        private IRepoUser repoU;

        public ControllerHelper(IRepoPost _repoP, IRepoUser _repoU)
        {
            repoP = _repoP;
            repoU = _repoU;
        }
        public string GetUserId(ClaimsPrincipal user)
        {
            var claimsIdentity = user.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                var userIdClaim = claimsIdentity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                if (userIdClaim != null)
                {
                    var userIdValue = userIdClaim.Value;
                    return userIdValue;
                }
            }
            return null;
        }
        public List<string> UploadImages(List<IFormFile> files, IHostingEnvironment hostingEnvironment, string fileFolder)
        {
            List<string> pathToImages = new List<string>();
            foreach (var file in files)
            {
                pathToImages.Add(ProcessImage(file, hostingEnvironment, fileFolder));
            }

            return pathToImages;
        }
        public string UploadImage(IFormFile file, IHostingEnvironment hostingEnvironment, string fileFolder)
        {

            return ProcessImage(file, hostingEnvironment, fileFolder); ;
        }

        private string ProcessImage(IFormFile file, IHostingEnvironment hostingEnvironment, string fileFolder)
        {
            string[] validFileTypes = { "png", "jpeg", "gif" , "jpg"};
            string ext;
            ext = Path.GetExtension(file.FileName);
            for (int i = 0; i < validFileTypes.Length; i++)
            {
                if (ext == "." + validFileTypes[i])
                {
                    var uniqueFileName = GetUniqueFileName(file.FileName);
                    var uploads = Path.Combine(hostingEnvironment.WebRootPath, fileFolder);
                    var filePath = Path.Combine(uploads, uniqueFileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return $"~/{fileFolder}/{uniqueFileName}";
                }
            }
            return null;
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }

        public IActionResult Like(int postId)
        {
            int likeOp = 0;
                Post post = repoP.GetById(postId);
                User user = repoU.GetById(GetUserId(User));
                likeOp = repoP.LikePost(post, user);
            return Json(new { id = postId, likeOperation = likeOp });
        }
        public IActionResult Dislike(int postId)
        {
            int likeOp = 0;
                Post post = repoP.GetById(postId);
                User user = repoU.GetById(GetUserId(User));
                likeOp = repoP.DislikePost(post, user);
            return Json(new { id = postId, likeOperation = likeOp });
        }
        //retourne le post auquel il répond
        public Post Reply(int inResponseToId, ReplyViewModel model, IHostingEnvironment hostingEnvironment)
        {
            Post response = new Post();
            response.PostContent = model.PostContent;
            response.PostTime = DateTime.Now;
            response.IsOriginalPost = false;
            response.Poster = repoU.GetById(GetUserId(User));
            if (model.Images != null)
            {
                List<string> imagesPath = UploadImages(model.Images, hostingEnvironment, "imagesupload");
                List<PostImage> postimages = new List<PostImage>();
                foreach (var path in imagesPath)
                {
                    postimages.Add(new PostImage
                    {
                        Url = path,
                        Post = response,
                    });
                }
                response.Images = postimages;
            }
            Post inResponseTo = repoP.GetById(inResponseToId);

            repoP.ReplyToPost(inResponseTo, response);
            return inResponseTo;
        }

        public void EditPost(int postId, CreateEditPostViewModel model, IHostingEnvironment hostingEnvironment)
        {
            Post postToUpdate = repoP.GetById(postId);
            postToUpdate.PostContent = model.PostContent;
            if (model.Images != null)
            {
                List<string> imagesPath = UploadImages(model.Images, hostingEnvironment, "imagesupload");
                List<PostImage> postimages = new List<PostImage>();
                foreach (var path in imagesPath)
                {
                    postimages.Add(new PostImage
                    {
                        Url = path,
                        Post = postToUpdate,
                    });
                }
                postToUpdate.Images = postimages;
            }
            repoP.UpdatePost(postToUpdate);
        }
    }
}
