using Socialnetwork.Webclient.Data;
using SocialNetwork.Data.Models;
using SocialNetwork.Data.Models.IdentityModels;
using SocialNetwork.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<User> GetFollowers(string id)
        {
            return ctx.FollowersFollowed.Where(f => f.FollowedId == id).Select(u => u.Follower).ToList();
            
        }

        public int AddFollower(User Followed, User Follower)
        {
            ctx.FollowersFollowed.Add(new FollowersFollowed {
                FollowedId = Followed.UserId,
                FollowerId = Follower.UserId,
                Followed = Followed,
                Follower = Follower });

            return ctx.SaveChanges();
        }

        

    }
}
