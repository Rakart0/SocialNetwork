using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Socialnetwork.Webclient.Controllers.Converters;
using Socialnetwork.Webclient.Helpers;
using Socialnetwork.Webclient.Models;
using SocialNetwork.Data.Models;
using SocialNetwork.Data.Repository.Interfaces;

namespace Socialnetwork.Webclient.Controllers
{
    public class GroupController : Controller
    {
        private IRepoGroup repoG;
        private IRepoUser repoU;
        private IControllerHelper cHelper;
        public GroupController(IRepoGroup _repoG, IRepoUser _repoU, IControllerHelper _cHelper)
        {
            repoG = _repoG;
            repoU = _repoU;
            cHelper = _cHelper;
        }
        // GET: Group
        public ActionResult Index()
        {
            return View(repoG.GetAll().ToUI());
        }

        // GET: Group/Details/5
        public ActionResult Details(int id)
        {
            Group g = repoG.GetById(id);
            return View(repoG.GetById(id).ToUI());
        }

        // GET: Group/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Group/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Group model)
        {
            try
            {
                // TODO: Add insert logic here
                model.Admin = repoU.GetById(cHelper.GetUserId(User));
                repoG.AddGroup(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Group/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Group/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GroupViewModel model)
        {
            try
            {
                model.GroupId = id;
                repoG.UpdateGroup(model.ToData());

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Group/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Group/Delete/5
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