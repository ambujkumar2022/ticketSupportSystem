namespace TicketSystem.API.DTOs
{
    public class CreateTicketDto
    {
        public string Title { get; set; }
        public string Description {  get; set; }
        public int CreatedBy { get; set; }

    }
}
