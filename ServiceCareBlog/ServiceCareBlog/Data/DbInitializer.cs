using ServiceCareBlog.Data.Entities;
using System.Linq;

namespace ServiceCareBlog.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BloggingContext context)
        {
            context.Database.EnsureCreated();

            if (context.Posts.Any())
            {
                return;
            }

            var blogs = new Post[]
            {
                new Post{ Title="Pierwszy Post", Content="Zawartość" },
                new Post{ Title="Drugi Post", Content="Lorum" },
            };

            context.Posts.AddRange(blogs);
            context.SaveChanges();
        }
    }
}
