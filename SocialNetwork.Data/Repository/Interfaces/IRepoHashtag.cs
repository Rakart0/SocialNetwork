using SocialNetwork.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Data.Repository.Interfaces
{
    public interface IRepoHashtag
    {
        IEnumerable<Hashtag> GetAll();
        Hashtag GetById(int id);
        int AddHashtag(Hashtag h);
        int UpdateHashtag(Hashtag updatedH);
        int DeleteHashtag(int id);
    }
}
