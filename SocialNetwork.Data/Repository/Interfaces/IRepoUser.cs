using SocialNetwork.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Data.Repository.Interfaces
{
    public interface IRepoUser
    {
        IEnumerable<User> GetAll();
        User GetById(string id);
        int AddUser(User u);
        int UpdateUser(int id);
        int DeleteUser(int id);

    }
}
