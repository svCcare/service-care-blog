using ServiceCareBlog.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceCareBlog.Data
{
    public class BloggingRepository : IBloggingRepository
    {
        private readonly BloggingContext _bloggingContext;

        public BloggingRepository(BloggingContext bloggingContext)
        {
            _bloggingContext = bloggingContext;
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _bloggingContext.Posts
                .ToList();
        }
    }
}
