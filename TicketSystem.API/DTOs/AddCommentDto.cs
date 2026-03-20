namespace TicketSystem.API.DTOs
{
    public class AddCommentDto
    {
        public int TicketId { get; set; }
        public string Comment { get; set; }
        public int CreatedBy { get; set; }
    }
}
