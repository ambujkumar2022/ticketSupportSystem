using TicketSystem.API.Models;

namespace TicketSystem.API.DTOs
{
    public class UpdateStatusDto
    {
        public int TicketId { get; set; }
        public TicketStatus Status { get; set; }
    }
}
