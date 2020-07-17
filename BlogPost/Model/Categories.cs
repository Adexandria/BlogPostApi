using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPost_userpost_.Model
{
    public class Categories : ICategory
    { private readonly BlogDb db;
        public Categories(BlogDb db)
        {
            this.db = db;
        }
        public IEnumerable<Category> GetCategories
        {
            get
            {
                return db.Categories.OrderBy(r=>r.CategoryId);
            }
        }

    }
}
