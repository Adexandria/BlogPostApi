using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using BlogPost_userpost_.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogPost_userpost_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Blog : Controller
    {

        private readonly IBlog log;
        public Blog(IBlog log)
        {

            this.log = log;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(log.GetBlogPosts);
        }
        [HttpGet("{categories}")]
        public IActionResult Category()
        {
            return Ok(log.GetCategory);
        }
        [HttpGet("Search")]
        public IActionResult Search(int type)
        {
            try
            {
                var query = log.Search(type);
                if (query == null)
                {
                    return Ok(query);

                }
                else
                {
                    return NotFound("Category not found");
                }
            } catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpPut("{Update}")]
        public IActionResult Put(int id, BlogPost post)
        {

            if (id != post.Id)
            {
                return NotFound();
            }
            try
            {
                log.Update(post);
                log.Commit();
                return Ok("Updated");
            }
            catch (DbUpdateConcurrencyException)
            {
                var query = log.GetBlog(id);
                if (query == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }


        }
        [HttpPost]
        public IActionResult Post(BlogPost blog)
        {
            try
            {
                var query = log.GetBlog(blog.Id);
                if (query == null)
                {
                    log.Add(blog);
                    log.Commit();
                    return Created("Blog posted", blog);
                }
                else
                {
                    return BadRequest("Blog is occupied");
                }
            } catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
       

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            log.Delete(id);
            log.Commit();
            return Ok("Blog Deleted");
        }
       

    }
}
