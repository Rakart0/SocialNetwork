using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Data.Models.IdentityModels;

namespace Socialnetwork.Webclient.Controllers
{
    public class UserInfoController : Controller
    {


        UserManager<ApplicationUser> UserManager;

        public UserInfoController(UserManager<ApplicationUser> _usermanager)
        {
            UserManager = _usermanager;
        }

        public async Task<IActionResult> IndexAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                var appUser = await UserManager.FindByIdAsync(GetId());
                
                ViewBag.test = "pi";
            }
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