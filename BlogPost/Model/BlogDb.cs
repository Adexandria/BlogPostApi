using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPost_userpost_.Model
{
    public class BlogDb :DbContext
    {
        public BlogDb(DbContextOptions<BlogDb> options) : base(options)
        {

        }
        public DbSet<BlogPost> Blog { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder bldr)
        {

            bldr.Entity<BlogPost>().HasData(new 
            {
                Id = 1,

                Username = "Addie",
                Post = "Jaye jaye this song make sense die!!!!!!",
               CategoryId =1



            }) ;
            bldr.Entity<Category>().HasData(new 
            {
                CategoryId = 1,
                GetTypes = Types.Music
            });
        }
    }
}
