using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Data.Models;
using SocialNetwork.Data.Models.IdentityModels;
using SocialNetwork.Data.Repository.Interfaces;

namespace Socialnetwork.Webclient.Controllers
{
    public class UserInfoController : Controller
    {


        UserManager<ApplicationUser> UserManager;
        IRepoUser repo;

        public UserInfoController(UserManager<ApplicationUser> _usermanager, IRepoUser _repo)
        {
            UserManager = _usermanager;
            repo = _repo;
        }
        public IActionResult Index()
        {
            return View(repo.GetFollowing(GetId()));
        }

        public IActionResult Users()
        {
            return View(repo.GetAll());
        }

        public IActionResult Follow(string id)
        {
            if (User.Identity.IsAuthenticated)
            {
                repo.AddFollower(id, GetId());
            }
            return View("Index", repo.GetFollowing(GetId()));
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