using Socialnetwork.Webclient.Data;
using SocialNetwork.Data.Models;
using SocialNetwork.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.Data.Repository
{
    public class RepoPost : IRepoPost
    {
        ApplicationDbContext ctx;

        public RepoPost(ApplicationDbContext _context)
            {
            ctx = _context;
            }
        public IEnumerable<Post> GetAll()
        {
            return ctx.Posts;
        }
        public Post GetById(int id)
        {
            return ctx.Posts.Find(id);
        }
        public IEnumerable<PostLike> PostLike(int id)
        {
            return ctx.PostLike.Where(pl => pl.PostId == id).ToList();
        }
        public int AddPost(Post p)
        {
            ctx.Posts.Add(p);
            return ctx.SaveChanges();
        }

        public int DeletePost(int id)
        {
            throw new NotImplementedException();
        }

        public int UpdatePost(int id)
        {
            throw new NotImplementedException();
        }
        public int LikePost(Post post, User user)
        {
            return LikeOrDislike(post, user, true);
        }

        public int DislikePost(Post post, User user)
        {
            return LikeOrDislike(post, user, true);
        }
        private int LikeOrDislike(Post post, User user, bool like)
        {
            PostLike newPl = new PostLike
            {
                User = user,
                UserId = user.UserId,
                Post = post,
                PostId = post.PostId,
                Like = like
            };
            PostLike postLike = ctx.PostLike.FirstOrDefault(pl => pl.UserId == post.Poster.UserId && pl.UserId == user.UserId);
            if (postLike != null)
            {
                if (postLike.Like != like)
                {
                    ctx.PostLike.Add(newPl);
                }
                ctx.PostLike.Remove(postLike);
            }
            else
            {
                ctx.PostLike.Add(newPl);
            }
            return ctx.SaveChanges();
        }

    }
}
