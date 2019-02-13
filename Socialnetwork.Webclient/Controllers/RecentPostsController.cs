using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Socialnetwork.Webclient.Controllers.Converters;
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
        public ActionResult Index()
        {
            return View(repoP.GetAll().ToUi());
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Post/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        // POST: Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(Post p)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    p.PostTime = DateTime.Now;
                    p.IsOriginalPost = true;
                    p.Poster = repoU.GetById(GetId());
                    repoP.AddPost(p);
                }
                return View("Index", repoP.GetAll().ToUi());
            }
            catch
            {
                return View();
            }
        }
        // POST: Post/Like
        [Authorize]
        public ActionResult Like(int postId)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    Post post = repoP.GetById(postId);
                    User user = repoU.GetById(GetId());
                    repoP.LikePost(post, user);
                }
                return RedirectToAction("Index", repoP.GetAll().ToUi());
            }
            catch
            {
                return View();
            }
        }
        // POST: Post/Dislike
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Dislike(int postId)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    Post post = repoP.GetById(postId);
                    User user = repoU.GetById(GetId());
                    repoP.DislikePost(post, user);
                }
                return RedirectToAction("Index", repoP.GetAll().ToUi());
                //return View("Index", repoP.GetAll().ToUi());
            }
            catch
            {
                return View();
            }
        }
        public string GetId()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
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

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Post/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Post/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}