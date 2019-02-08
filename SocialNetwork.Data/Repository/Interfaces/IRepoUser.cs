using SocialNetwork.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Data.Repository.Interfaces
{
    public interface IRepoUser
    {
        IEnumerable<User> GetAll();
        User GetById();
        int AddUser();
        int DeleteUser();

    }
}
