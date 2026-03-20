namespace TicketSystem.API.Models
{
    public class TicketComment
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public int CreatedBy { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public Ticket Ticket { get; set; }
    }
}
