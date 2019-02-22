using SocialNetwork.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Data.Repository.Interfaces
    {
    interface IRepoGroupPost
        {
        IEnumerable<GroupPost> GetAll();
        GroupPost GetById(int id);
        int AddGroupPost(GroupPost p);
        int UpdateGroupPost(int id);
        int DeleteGroupPost(int id);
        }
    }
