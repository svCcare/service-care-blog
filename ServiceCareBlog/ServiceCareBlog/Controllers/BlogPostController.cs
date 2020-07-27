using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ServiceCareBlog.Data;
using ServiceCareBlog.Data.Entities;

namespace ServiceCareBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
    }
}