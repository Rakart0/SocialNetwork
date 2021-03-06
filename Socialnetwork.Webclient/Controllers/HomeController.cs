﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Socialnetwork.Webclient.Controllers.Converters;
using Socialnetwork.Webclient.Models;
using SocialNetwork.Data.Models;
using SocialNetwork.Data.Models.IdentityModels;
using SocialNetwork.Data.Repository;
using SocialNetwork.Data.Repository.Interfaces;
using Socialnetwork.Webclient.Controllers.Converters;

namespace Socialnetwork.Webclient.Controllers
{
    public class HomeController : Controller
    {
        IRepoUser repoU;
        IRepoGroup repoG;
        IRepoHashtag repoH;
        IRepoPost repoP;
        UserManager<ApplicationUser> UserManager;

        public HomeController(IRepoUser _repoU, IRepoGroup _repoG, IRepoHashtag _repoH, UserManager<ApplicationUser> _usermanager, IRepoPost _repoP)
        {
            repoU = _repoU;
            repoG = _repoG;
            repoH = _repoH;
            repoP = _repoP;
        }
 

        public IActionResult Index(string searchArea)
        {
            if(searchArea == null)
            {
                return View();
            }
            else if(searchArea.StartsWith("@"))
            {
                string userId = repoU.GetByName(searchArea.Replace("@", "")).UserId;
                return RedirectToAction("Detail", "UserInfo", new { id = userId });
            }
            else if(searchArea.StartsWith("/"))
            {
                int groupId = repoG.GetByName(searchArea.Replace("/", "")).GroupeId;
                return RedirectToAction("Details", "Group", new { id = groupId });
            }
            return View();
        }

        public IActionResult GetNumberOfAnswer(int id)
        {
            PostViewModel p = repoP.GetById(id).ToPostViewModel();
            return PartialView("~/Views/Shared/_PostAnswers.cshtml", p);

        }

        public IActionResult AnswerPost(int id)
        {
            //PostViewModel p = repoP.GetById(id).ToPostViewModel();
            //return PartialView("~/Views/Shared/PostAnswers.cshtml", p);
            ViewBag.value = id;
            return PartialView("~/Views/Shared/_UserReplyArea.cshtml");
        }
            
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Search(string term)
        {
            //1 = user //2 = group //3 = hashtag
            var usrResult = repoU.GetAll().Where(u => ("@" + u.UserName.ToLower()).Contains(term.ToLower())).Select(u => "@" + u.UserName);
            var groupResult = repoG.GetAll().Where(g => ("/" + g.GroupName.ToLower()).Contains(term.ToLower())).Select(g => "/" + g.GroupName);
            //var htResult = repoH.GetAll().Where(h => h.HashtagName.ToLower().StartsWith(term.ToLower()));
            if(usrResult != null && groupResult != null)
            {
                var totalResult = usrResult.Concat(groupResult);
                return Json(totalResult);
            }
            return null;
        }

        public IActionResult Dashboard()
        {
            return View(repoP.GetAll().Where(p => p.IsOriginalPost == true).ToThumbnail().OrderByDescending(p => p.PostId));
            
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
        
    }
}
