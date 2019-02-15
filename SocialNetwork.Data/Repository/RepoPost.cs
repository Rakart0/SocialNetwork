using Microsoft.EntityFrameworkCore;
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
            return ctx.Posts.FirstOrDefault(p => p.PostId == id);
        }
        public int AddPost(Post p)
        {
            ctx.Posts.Add(p);
            return ctx.SaveChanges();
        }
        public void ReplyToPost(Post inResponseTo, Post response)
        {
            if(inResponseTo.IsOriginalPost)
            {
                inResponseTo.Responses.Append(response);
                response.InResponseTo = inResponseTo;
                response.OriginalPost = inResponseTo;
            }
            else
            {
                inResponseTo.Responses.Append(response);
                response.InResponseTo = inResponseTo;
                response.OriginalPost = inResponseTo.OriginalPost;
            }
            AddPost(response);
            UpdatePost(inResponseTo.PostId);
        }

        public int DeletePost(int id)
        {
            Post p = GetById(id);
            if(p != null)
            {
                ctx.Remove(p);
                return ctx.SaveChanges();
            }
            return 0;
        }

        public int UpdatePost(int id)
        {
            Post post = GetById(id);
            if (post != null)
            {
                //Moyen efficace de remplacer les valeurs de l'objet en DB par celles de l'objet reçu.
                ctx.Entry(post).CurrentValues.SetValues(post);
                return ctx.SaveChanges();
            }
            return 0;
        }
        public int LikePost(Post post, User user)
        {
            return LikeOrDislike(post, user, true);
        }

        public int DislikePost(Post post, User user)
        {
            return LikeOrDislike(post, user, false);
        }
        //Retourne le nombre de like gagné ou perdu
        private int LikeOrDislike(Post post, User user, bool like)
        {
            int likeOp = 0;
            PostLike postLike = ctx.PostLike.FirstOrDefault(pl => pl.UserId == user.UserId && pl.PostId == post.PostId);
            if (postLike != null)
            {
                if (postLike.Like != like)
                {
                    postLike.Like = like;
                    ctx.Entry(postLike).CurrentValues.SetValues(postLike);
                    if (postLike.Like == true)
                    {
                        likeOp = 2;
                    }
                    else
                    {
                        likeOp = -2;
                    }
                }
                else
                {
                    ctx.PostLike.Remove(postLike);
                    if (postLike.Like == true)
                    {
                        likeOp = -1;
                    }
                    else
                    {
                        likeOp = 1;
                    }
                }
            }
            else
            {
                PostLike newPl = new PostLike
                {
                    User = user,
                    UserId = user.UserId,
                    Post = post,
                    PostId = post.PostId,
                    Like = like
                };
                ctx.PostLike.Add(newPl);
                if(newPl.Like == true)
                {
                    likeOp = 1;
                }
                else
                {
                    likeOp = -1;
                }
            }
            ctx.SaveChanges();
            return likeOp;
        }

    }
}
