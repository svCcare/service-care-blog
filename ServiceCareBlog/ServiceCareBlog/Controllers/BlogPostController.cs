using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceCareBlog.Data;
using ServiceCareBlog.Data.Entities;

namespace ServiceCareBlog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogPostController : ControllerBase
    {
        private readonly IBloggingRepository _bloggingRepository;

        public BlogPostController(IBloggingRepository bloggingRepository)
        {
            _bloggingRepository = bloggingRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Post>> Get()
        {
            try
            {
                return Ok(_bloggingRepository.GetAllPosts());
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get all posts");
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<Post> GetPostById(int id)
        {
            if (id > 0)
            {
                return Ok(_bloggingRepository.GetPostById(id));
            }
            else if (id < 0)
            {
                return BadRequest($"Failed to get post with id: {id}");
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Post>> CreatePost(Post postEntity)
        {
            await _bloggingRepository.CreatePost(postEntity);
            return CreatedAtAction(nameof(GetPostById), new { id = postEntity.PostId }, postEntity);
        }
    }
}