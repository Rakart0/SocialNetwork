using SocialNetwork.Data.Models;
using SocialNetwork.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Data.Repository
{
    public class RepoUser : IRepoUser
    {
        SocialNetworkContext ctx;

        public RepoUser(SocialNetworkContext _context)
        {
            ctx = _context;
        }

        public int AddUser(User u)
        {
            ctx.Users.Add(u);
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

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int UpdateUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
