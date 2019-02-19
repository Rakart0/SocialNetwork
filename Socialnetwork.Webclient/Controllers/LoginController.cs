using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Socialnetwork.Webclient.Areas.Identity.Pages.Account;
using Socialnetwork.Webclient.Models;
using SocialNetwork.Data.Models;
using SocialNetwork.Data.Models.IdentityModels;
using SocialNetwork.Data.Repository.Interfaces;

namespace Socialnetwork.Webclient.Controllers
{
    public class LoginController : Controller
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IRepoUser repo;

        public LoginController(
            SignInManager<ApplicationUser> _signInManager, 
            UserManager<ApplicationUser> _userManager,
            IRepoUser _repo)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            repo = _repo;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("../Home/index");

            }
            else
            {
                return View("signin");
            }
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(AuthViewModel authViewModel)
        {
            var p = authViewModel;

            var result = await signInManager.PasswordSignInAsync(authViewModel.UserName, authViewModel.LogPassword, authViewModel.RememberUser, lockoutOnFailure: true);

            
            if (result.Succeeded)
            {
                return Redirect("../Home/index");
            }
            return View("signin");
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync (AuthViewModel authViewModel)
        {

            
            if (!ModelState.IsValid)
            {
                return View("signin",authViewModel);

            }

            var userToRegister = new ApplicationUser
            {
                UserName = authViewModel.UserName,
                Email = authViewModel.Email
            };

            var result =await userManager.CreateAsync(userToRegister, authViewModel.Password);

            if (result.Succeeded)
            {
                var u = new User { UserName = userToRegister.UserName, ApplicationUser = userToRegister, Email = userToRegister.Email, UserPictureUrl = "www.google.be" };
                repo.AddUser(u);
                //_logger.LogInformation("User created a new account with password.");

                //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //var callbackUrl = Url.Page(
                //    "/Account/ConfirmEmail",
                //    pageHandler: null,
                //    values: new { userId = user.Id, code = code },
                //    protocol: Request.Scheme);

                //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                await signInManager.SignInAsync(userToRegister, isPersistent: false);
                return LocalRedirect("Index");
            }


            return View();
        }

    }
}