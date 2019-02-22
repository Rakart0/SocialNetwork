using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        UserManager<ApplicationUser> UserManager;
        IRepoPost repoP;
        IRepoUser repoU;

        public RecentPostsController(UserManager<ApplicationUser> _usermanager, IRepoPost _repoP, IRepoUser _repoU)
        {
            UserManager = _usermanager;
            repoP = _repoP;
            repoU = _repoU;
        }
        // GET: Post
        [HttpGet]
        public IActionResult Index()
        {
            return View(repoP.GetAll().Where(p => p.IsOriginalPost == true).ToThumbnail().OrderByDescending(p => p.PostTime));
        }

        // GET: Post/Create
        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        // POST: Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create(Post post)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    post.PostTime = DateTime.Now;
                    post.IsOriginalPost = true;
                    post.Poster = repoU.GetById(ControllerHelper.GetUserId(User));
                    repoP.AddPost(post);
                }
                return View(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [Authorize]
        public IActionResult Like(int postId)
        {
            try
            {
                int likeOp = 0;
                if (User.Identity.IsAuthenticated)
                {
                    Post post = repoP.GetById(postId);
                    User user = repoU.GetById(ControllerHelper.GetUserId(User));
                    likeOp = repoP.LikePost(post, user);
                }
                return Json(new { id = postId, likeOperation = likeOp });
            }
            catch
            {
                return Json("Erreur dans la méthode Like du controller RecentPosts");
            }
        }
        [Authorize]
        public IActionResult Dislike(int postId)
        {
            try
            {
                int likeOp = 0;
                if (User.Identity.IsAuthenticated)
                {
                    Post post = repoP.GetById(postId);
                    User user = repoU.GetById(ControllerHelper.GetUserId(User));
                    likeOp = repoP.DislikePost(post, user);
                }
                return Json(new { id = postId, likeOperation = likeOp });
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: Post/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                repoP.UpdatePost(id);
                return RedirectToAction(nameof(Index));
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
            return View(repoP.GetById(postId).ToReplyViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        [Route("/RecentPosts/Reply/", Name = "inResponseId")]
        public IActionResult Reply(int inResponseToId, ReplyViewModel rvm)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    Post response = new Post();
                    response.PostContent = rvm.PostContent;
                    response.PostTime = DateTime.Now;
                    response.IsOriginalPost = false;
                    response.Poster = repoU.GetById(ControllerHelper.GetUserId(User));
                    Post inResponseTo = repoP.GetById(inResponseToId);

                    repoP.ReplyToPost(inResponseTo, response);
                    if(inResponseTo.IsOriginalPost == true)
                    {
                        return RedirectToAction(nameof(Post), inResponseTo.OriginalPost.PostId);
                    }
                    return RedirectToAction(nameof(Post), inResponseTo);
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