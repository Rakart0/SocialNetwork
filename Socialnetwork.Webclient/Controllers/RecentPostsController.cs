using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Socialnetwork.Webclient.Controllers.Converters;
using Socialnetwork.Webclient.Helpers;
using Socialnetwork.Webclient.Models;
using SocialNetwork.Data.Models;
using SocialNetwork.Data.Models.IdentityModels;
using SocialNetwork.Data.Repository.Interfaces;

namespace Socialnetwork.Webclient.Controllers
{
    public class RecentPostsController : Controller
    {
        //Permet d'avoir le path root du serveur
        private readonly IHostingEnvironment hostingEnvironment;
        private UserManager<ApplicationUser> UserManager;
        private IRepoPost repoP;
        private IRepoUser repoU;
        private IControllerHelper cHelper;

        public RecentPostsController(UserManager<ApplicationUser> _usermanager, IRepoPost _repoP, IRepoUser _repoU, IHostingEnvironment environment, IControllerHelper _cHelper)
        {
            this.UserManager = _usermanager;
            this.repoP = _repoP;
            this.repoU = _repoU;
            this.hostingEnvironment = environment;
            this.cHelper = _cHelper;
        }
        // GET: Post
        [HttpGet]
        public IActionResult Index()
        {
            return View(repoP.GetAll().Where(p => p.IsOriginalPost == true).ToThumbnail().OrderByDescending(p => p.PostTime));
        }

        [HttpPost]
        public JsonResult CreateNew(Post post)
        {
            var p = post;
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    post.PostTime = DateTime.Now;
                    post.IsOriginalPost = true;
                    post.Poster = repoU.GetById(ControllerHelper.GetUserId(User));
                    repoP.AddPost(post);
                }
                return Json(true);
            }
            catch
            {
                return Json(true);
            }

        }

        // GET: Post/Create
        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View(new CreateEditPostViewModel());
        }
        // POST: Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create(CreateEditPostViewModel model)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    if (ModelState.IsValid)
                    {
                        Post post = new Post();
                        post.PostContent = model.PostContent;
                        post.PostTime = DateTime.Now;
                        post.IsOriginalPost = true;
                        post.Poster = repoU.GetById(cHelper.GetUserId(User));
                        if(model.Images != null)
                        {
                            List<string> imagesPath = cHelper.UploadImages(model.Images, hostingEnvironment, "imagesupload");
                            List<PostImage> postimages = new List<PostImage>();
                            foreach(var path in imagesPath)
                            {
                                postimages.Add(new PostImage
                                {
                                    Url = path,
                                    Post = post,
                                });
                            }
                            post.Images = postimages;
                        }
                        repoP.AddPost(post);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }
        [Authorize]
        public IActionResult Like(int postId)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    return cHelper.Like(postId);
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        [Authorize]
        public IActionResult Dislike(int postId)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    return cHelper.Dislike(postId);
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Edit/5
        public IActionResult Edit(int id)
        {
            return View(repoP.GetById(id).ToEditViewModel());
        }

        // POST: Post/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CreateEditPostViewModel model)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    cHelper.EditPost(id, model, hostingEnvironment);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: Post/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                repoP.DeletePost(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Post(int postId)
        {
            return View(repoP.GetById(postId).ToPostViewModel());
        }
        [HttpGet]
        [Authorize]
        public IActionResult Reply(int postId)
        {
            if (User.Identity.IsAuthenticated)
            {
                return View(repoP.GetById(postId).ToReplyViewModel());
            }
            return View();
        }
        public IActionResult GetReply(int postId)
        {
            return View();
        }

        [HttpPost]
        public JsonResult AnswerToPost(ReplyViewModel rvm)
        {
            if (User.Identity.IsAuthenticated)
            {
                Post response = new Post();
                response.PostContent = rvm.PostContent;
                response.PostTime = DateTime.Now;
                response.IsOriginalPost = false;
                response.Poster = repoU.GetById(ControllerHelper.GetUserId(User));
                Post inResponseTo = repoP.GetById(rvm.InResponseToId);

                repoP.ReplyToPost(inResponseTo, response);
                return Json(true);
            }
            return Json(false);
        }

        [HttpPost]
        [Route("/RecentPosts/Reply/", Name = "inResponseId")]
        public IActionResult Reply(int inResponseToId, ReplyViewModel model)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    Post inResponseTo = cHelper.Reply(inResponseToId, model, hostingEnvironment);
                    if (inResponseTo.IsOriginalPost == true)
                    {
                        return RedirectToAction(nameof(Post), inResponseToId);
                    }
                    return RedirectToAction(nameof(Post), inResponseTo.OriginalPost.PostId);
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}