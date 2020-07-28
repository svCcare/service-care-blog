using ServiceCareBlog.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceCareBlog.Data
{
    public interface IBloggingRepository
    {
        Post GetPostById(int id);

        IEnumerable<Post> GetAllPosts();

        Task<int> CreatePost(Post postEntity);

        Task<Post> DeletePostById(int id);

    }
}
