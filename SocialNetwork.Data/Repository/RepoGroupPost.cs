using Socialnetwork.Webclient.Data;
using SocialNetwork.Data.Models;
using SocialNetwork.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Data.Repository
    {
    public class RepoGroupPost : IRepoGroupPost
        {
        ApplicationDbContext ctx;

        public RepoGroupPost(ApplicationDbContext _context)
            {
                ctx = _context;
            }

        public int AddGroupPost(GroupPost p)
            {
            ctx.GroupPosts.Add(p);
            return ctx.SaveChanges();
            }

        public int DeleteGroupPost(int id)
            {
            throw new NotImplementedException();
            }

        public IEnumerable<GroupPost> GetAll()
            {
            return ctx.GroupPosts;
            }

        public GroupPost GetById(int id)
            {
            return ctx.GroupPosts.Find(id);
            }

        public int UpdateGroupPost(int id)
            {
            throw new NotImplementedException();
            }
        }
    }
