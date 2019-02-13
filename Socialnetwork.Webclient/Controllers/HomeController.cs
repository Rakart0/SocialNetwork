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
