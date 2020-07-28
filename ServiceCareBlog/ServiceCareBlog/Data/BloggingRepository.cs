using ServiceCareBlog.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceCareBlog.Data
{
    public class BloggingRepository : IBloggingRepository
    {
        private readonly BloggingContext _bloggingContext;

        public BloggingRepository(BloggingContext bloggingContext)
        {
            _bloggingContext = bloggingContext;
        }

        public Post GetPostById(int id)
        {
            return _bloggingContext.Posts
                .FirstOrDefault(p => id == p.PostId);
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _bloggingContext.Posts
                .ToList();
        }

        public async Task<int> CreatePost(Post postEntity)
        {
            _bloggingContext.Posts.Add(postEntity);
            return await _bloggingContext.SaveChangesAsync();
        }
    }
}
