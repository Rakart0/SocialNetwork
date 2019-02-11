using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Socialnetwork.Webclient.Models;
using SocialNetwork.Data.Models;
using SocialNetwork.Data.Models.IdentityModels;
using SocialNetwork.Data.Repository;
using SocialNetwork.Data.Repository.Interfaces;

namespace Socialnetwork.Webclient.Controllers
{
    public class HomeController : Controller
    {
        IRepoUser repo;
        UserManager<ApplicationUser> UserManager;

        public HomeController(IRepoUser _repo, UserManager<ApplicationUser> _usermanager)
        {
            repo = _repo;
            UserManager = _usermanager;
        }

        public IActionResult Index()
        {
            var ua = new List<User>();
            if (User.Identity.IsAuthenticated)
            {
                var InfoUser = repo.GetById(GetId());
                var testR = InfoUser.UserPictureUrl;
                 ua = repo.GetFollowers(GetId()).ToList();
                
            ViewBag.test = testR;
            }
            return View(ua);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //Note : oué oué c'est de la merde mais c'est juste pour vérifier que ça fonctionne bien.
        public IActionResult Users()
        {
            
            return View(repo.GetAll());
        }

        public IActionResult Follow()
        {
            var ua = new List<User>();

            return View();
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
