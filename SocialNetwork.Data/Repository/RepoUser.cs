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

        public IEnumerable<User> GetFollowing(string id)
        {
            return ctx.FollowersFollowed.Where(f => f.FollowerId == id).Select(u => u.Followed).ToList();

        }



        public int AddFollower(string _FollowedId, string _FollowerId)
        {
            //Oui oui c'est de la merde c'est en cours de debug
            User pfollower = GetById(_FollowerId);
            User pfollowed = GetById(_FollowedId);

            ctx.FollowersFollowed.Add(new FollowersFollowed {
                FollowedId = _FollowedId,
                FollowerId = _FollowerId,
                Followed = pfollowed,
                Follower = pfollower });


            return ctx.SaveChanges();
        }
    }
}
