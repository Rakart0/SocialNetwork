using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Socialnetwork.Webclient.Models;
using SocialNetwork.Data.Repository;
using SocialNetwork.Data.Repository.Interfaces;

namespace Socialnetwork.Webclient.Controllers
{
    public class HomeController : Controller
    {
        IRepoUser repo;

        public HomeController(IRepoUser _repo)
        {
            repo = _repo;
        }

        public IActionResult Index()
        {
            return View();
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
    }
}
