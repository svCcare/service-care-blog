using ServiceCareBlog.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceCareBlog.Data
{
    public interface IBloggingRepository
    {
        IEnumerable<Post> GetAllPosts();
    }
}
