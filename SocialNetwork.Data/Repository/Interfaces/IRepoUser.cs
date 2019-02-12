using SocialNetwork.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Data.Repository.Interfaces
{
    public interface IRepoUser
    {
        //Crud
        IEnumerable<User> GetAll();
        User GetById(string id);
        int AddUser(User u);
        int UpdateUser(int id);
        int DeleteUser(int id);


        //Trucs réels
        IEnumerable<User> GetFollowers(string id);
        IEnumerable<User> GetFollowing(string id);
        int AddFollower(string _FollowedId, string _FollowerId);
    }
}
