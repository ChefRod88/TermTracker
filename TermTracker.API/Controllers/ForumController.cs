using Microsoft.AspNetCore.Mvc;
using TermTracker.API.Data;
using TermTracker.API.Models;

namespace TermTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ForumController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ForumController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = _context.ForumPosts.OrderByDescending(p => p.Timestamp).ToList();
            return Ok(posts);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] ForumPost post)
        {
            post.Timestamp = DateTime.UtcNow;

            _context.ForumPosts.Add(post);
            await _context.SaveChangesAsync();

            return Ok(post);
        }
    }
}

