using SocialNetwork.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Data.Repository.Interfaces
{
    public interface IRepoGroup
    {
        IEnumerable<Group> GetAll();
        Group GetById(int id);
        Group GetByName(string name);
        int AddGroup(Group g);
        int UpdateGroup(Group updatedG);
        int DeleteGroup(int id);
    }
}
