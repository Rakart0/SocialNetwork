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
        IEnumerable<User> GetAllWithFollowing();

        User GetById(string id);
        User GetByName(string name);
        User GetByIdWithFollowing(string id);

        int AddUser(User u);
        int UpdateUser(int id);
        int DeleteUser(int id);



        //Trucs réels
        IEnumerable<User> GetFollowers(string id);
        IEnumerable<User> GetFollowing(string id);
        int AddFollower(string _FollowedId, string _FollowerId);
        int DeleteFollower(string _FollowedId, string _FollowerId);
        bool IsFollowing(string followerId, string followedId);

    }
}
