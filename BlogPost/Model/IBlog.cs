using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPost_userpost_.Model
{
  public interface IBlog
    {
        IEnumerable<BlogPost> GetBlogPosts { get; }
        BlogPost GetBlog(int id);
        IEnumerable<BlogPost> Search(int categories);
        IEnumerable<Category> GetCategory { get; }

        BlogPost Add(BlogPost blog);
        int Delete(int id);
        int Commit();
        BlogPost Update(BlogPost p);
    }
}
