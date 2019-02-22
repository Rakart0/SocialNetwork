using SocialNetwork.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Data.Repository.Interfaces
{
    public interface IRepoPost
    {
        //Crud
        IEnumerable<Post> GetAll();
        Post GetById(int id);
        int AddPost(Post p);
        void ReplyToPost(Post post, Post postResponse);
        int UpdatePost(Post updatedP);
        int DeletePost(int id);
        //
        int LikePost(Post post, User user);
        int DislikePost(Post post, User user);
    }
}
