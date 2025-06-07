using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermTracker.Models.StudentLounge
{
    /// <summary>
    /// Model representing a chat message in the student lounge.
    /// </summary>
    public class ChatMessage
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
    }

}

