using Microsoft.AspNetCore.Mvc;
using TermTracker.API.Data;
using TermTracker.API.Models;

namespace TermTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ChatController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            var messages = _context.ChatMessages
                .OrderByDescending(m => m.Timestamp)
                .Take(50)
                .ToList();

            return Ok(messages);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] ChatMessage message)
        {
            message.Timestamp = DateTime.UtcNow;

            _context.ChatMessages.Add(message);
            await _context.SaveChangesAsync();

            return Ok(message);
        }
    }
}

