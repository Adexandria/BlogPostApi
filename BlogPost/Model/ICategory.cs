using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPost_userpost_.Model
{
  public interface ICategory
    {
        IEnumerable<Category> GetCategories { get; }

    }
}
