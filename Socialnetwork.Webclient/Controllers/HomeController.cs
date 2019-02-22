using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        UserManager<ApplicationUser> UserManager;

        public HomeController(IRepoUser _repoU, IRepoGroup _repoG, IRepoHashtag _repoH, UserManager<ApplicationUser> _usermanager)
        {
            repoU = _repoU;
            repoG = _repoG;
            repoH = _repoH;
            UserManager = _usermanager;
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
            }
            else if(searchArea.StartsWith("/"))
            {
                int groupId = repoG.GetByName(searchArea.Replace("/", "")).GroupeId;
                return RedirectToAction("Details", "Group", new { id = groupId });
            }
            return View();
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
