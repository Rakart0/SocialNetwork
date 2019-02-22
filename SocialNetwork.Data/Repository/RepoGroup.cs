using Socialnetwork.Webclient.Data;
using SocialNetwork.Data.Models;
using SocialNetwork.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.Data.Repository
{
    public class RepoGroup : IRepoGroup
    {
        ApplicationDbContext ctx;
        public RepoGroup(ApplicationDbContext _context)
        {
            ctx = _context;
        }
        public IEnumerable<Group> GetAll()
        {
            return ctx.Groups;
        }
        public Group GetById(int id)
        {
            Group group = ctx.Groups.Find(id);
            if(group != null)
            {
                return group;
            }
            return null;
        }
        public Group GetByName(string name)
        {
            return ctx.Groups.Where(g => g.GroupName.ToLower().Contains(name.ToLower())).First();
        }
        public int AddGroup(Group g)
        {
            ctx.Groups.Add(g);
            return ctx.SaveChanges();
        }
        public int UpdateGroup(Group updatedG)
        {
            if (updatedG != null)
            {
                ctx.Entry(updatedG).CurrentValues.SetValues(updatedG);
                return ctx.SaveChanges();
            }
            return 0;
        }
        public int DeleteGroup(int id)
        {
            Group g = GetById(id);
            if (g != null)
            {
                ctx.Remove(g);
                return ctx.SaveChanges();
            }
            return 0;
        }



    }
}
