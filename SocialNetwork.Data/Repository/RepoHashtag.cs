using Socialnetwork.Webclient.Data;
using SocialNetwork.Data.Models;
using SocialNetwork.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Data.Repository
{
    public class RepoHashtag : IRepoHashtag
    {
        ApplicationDbContext ctx;
        public RepoHashtag(ApplicationDbContext _context)
        {
            ctx = _context;
        }
        public IEnumerable<Hashtag> GetAll()
        {
            return ctx.Hashtags;
        }
        public Hashtag GetById(int id)
        {
            Hashtag hashtag = ctx.Hashtags.Find(id);
            if (hashtag != null)
            {
                return hashtag;
            }
            return null;
        }
        public int AddHashtag(Hashtag h)
        {
            ctx.Hashtags.Add(h);
            return ctx.SaveChanges();
        }
        public int UpdateHashtag(Hashtag updatedH)
        {
            if (updatedH != null)
            {
                ctx.Entry(updatedH).CurrentValues.SetValues(updatedH);
                return ctx.SaveChanges();
            }
            return 0;
        }
        public int DeleteHashtag(int id)
        {
            Hashtag h = GetById(id);
            if (h != null)
            {
                ctx.Remove(h);
                return ctx.SaveChanges();
            }
            return 0;
        }
    }
}
