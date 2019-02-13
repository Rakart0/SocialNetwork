using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<User> GetAllWithFollowing()
        {
            return ctx.Users.Include(u => u.Following);
        }

        public int DeleteFollower(string _FollowedId, string _FollowerId)
        {
            var followrelationship = ctx.FollowersFollowed.FirstOrDefault(f => f.FollowerId == _FollowerId && f.FollowedId == _FollowedId);
            ctx.FollowersFollowed.Remove(followrelationship);
            return ctx.SaveChanges();
        }


        public User GetById(string id)
        {
            return ctx.Users.Find(id);
        }

        public User GetByIdWithFollowing(string id)
        {
            return ctx.Users.Include(u => u.Following).FirstOrDefault(user => user.UserId == id);
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
            //Cette façon est plus logique mais tellement plus crade de merde que j'ai envie de mourir.
            //var c = ctx.Users.Include(user => user.Following).ThenInclude(following => following.Followed).FirstOrDefault(u => u.UserId == id).Following.Select(x => x.Followed).ToList();

            //var c1 = ctx.Entry(GetById(id)).Collection(u => u.Following).
            //    Query().ToList();

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

        public bool IsFollowing (string followerId, string followedId)
        {
            //var a = ctx.FollowersFollowed.Where(f => f.FollowerId == followedId);
            //var b = a.Select(p => p.FollowedId).Contains(followedId);
            var a = ctx.FollowersFollowed.Where(f => f.FollowerId == followedId).Select(p => p.FollowedId).Contains(followedId);
            return a;
        }
        
    }
}
