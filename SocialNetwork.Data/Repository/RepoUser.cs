using Socialnetwork.Webclient.Data;
using SocialNetwork.Data.Models;
using SocialNetwork.Data.Models.IdentityModels;
using SocialNetwork.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Data.Repository
{
    public class RepoUser : IRepoUser
    {
        ApplicationDbContext ctx;

        public RepoUser(ApplicationDbContext _context)
        {
            ctx = _context;
        }

        public int AddUser(User u)
        {
            ctx.Users.Add(u);
            //ctx.ApplicationUser.Update()
            return ctx.SaveChanges();
            
        }

        public int DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            return ctx.Users;
        }

        public User GetById(string id)
        {
            return ctx.Users.Find(id);
        }

        public int UpdateUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
