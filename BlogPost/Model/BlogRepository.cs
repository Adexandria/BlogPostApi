using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace BlogPost_userpost_.Model
{
    public class BlogRepository : IBlog
    {
        private readonly BlogDb db;
        public BlogRepository(BlogDb db)
        {
            this.db = db;
        }
        public IEnumerable<BlogPost> GetBlogPosts
        {
            get
            {
                return db.Blog.OrderBy(r=>r.Id).Include(c=>c.Category);
            }
        }

        

        public BlogPost Add(BlogPost blog)
        {
            
            db.Blog.Add(blog);
            return blog;
        }

        public int Commit()
        {
            
            return db.SaveChanges();
        }

        public int Delete(int id)
        {
            var query = GetBlog(id);
            if(query != null)
            {
                db.Blog.Remove(query);
                return db.SaveChanges();
            }
            return 0;
        }

        public BlogPost GetBlog(int id)
        {
            return db.Blog.Where(r => r.Id == id).Include(c=>c.Category).FirstOrDefault();
        }

        public IEnumerable<Category> GetCategory
        {
            get
            {
                return db.Categories.OrderBy(r=>r.CategoryId);
            }
        }
        

        public IEnumerable<BlogPost> Search(int categories)
        {

         return  db.Blog.Where(r => r.Category.CategoryId==categories).Include(c=>c.Category);
            
            
            
        }

        public BlogPost Update(BlogPost post)
        {
            var updatedEntity = db.Blog.Attach(post);
            updatedEntity.State = EntityState.Modified;
            return post;

        }
    }
}
