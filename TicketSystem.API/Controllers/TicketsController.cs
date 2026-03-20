using Microsoft.AspNetCore.Mvc;
using TicketSystem.API.DBContext;
using TicketSystem.API.DTOs;
using TicketSystem.API.Models;

namespace TicketSystem.API.Controllers
{
    [ApiController]
    [Route("api/tickets")]
    public class TicketsController : ControllerBase
    {
        private readonly AppDBContext _dbContext;
        public TicketsController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Create Ticket
        [HttpPost]
        public IActionResult Create(CreateTicketDto dto)
        {
            if (string.IsNullOrEmpty(dto.Title))
                return BadRequest("Title is Required");

            var ticket = new Ticket
            {
                Title = dto.Title,
                Description = dto.Description,
                Status = TicketStatus.Open,
                CreatedAt = DateTime.Now,
                CreatedBy = dto.CreatedBy

            };

            _dbContext.Tickets.Add(ticket);
            _dbContext.SaveChanges();

            return Ok(ticket);
        }

        //Get Ticket List
        [HttpGet]
        public IActionResult GetAll()
        {
            var tickets = _dbContext.Tickets.ToList();
            return Ok(tickets);
        }

        //Get TicketDetails
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ticket = _dbContext.Tickets.Where(x => x.Id == id)
                         .Select(x => new
                         {
                             x.Id,
                             x.Title,
                             x.Description,
                             x.Status,
                             x.AssignedTo,
                             Comments = _dbContext.TicketComments
                                        .Where(c => c.TicketId == x.Id)
                                        .ToList()
                         }).FirstOrDefault();

            if (ticket == null)
                return NotFound();

            return Ok(ticket);
        }

        //Assign Ticket
        [HttpPost("assign")]
        public IActionResult Assign(AssignTicketDto dto)
        {
            var ticket = _dbContext.Tickets.Find(dto.TicketId);
            if (ticket == null)
                return NotFound("Ticket Not Found");

            var user = _dbContext.Users.Find(dto.AssignedTo);
            if (user == null)
                return BadRequest("User Not Found");

            ticket.AssignedTo = dto.AssignedTo;
            ticket.Status = TicketStatus.InProgress;

            _dbContext.SaveChanges();

            return Ok(ticket);
        }

        //Update Ticket Status
        [HttpPost("status")]
        public IActionResult UpdateStatus(UpdateStatusDto dto)
        {
            var ticket = _dbContext.Tickets.Find(dto.TicketId);
            if (ticket == null)
                return NotFound("Ticket Not Found");

            ticket.Status = dto.Status;
            _dbContext.SaveChanges();

            return Ok(ticket);
        }

        //Add Comments
        [HttpPost("comment")]
        public IActionResult AddComment(AddCommentDto dto)
        {
            var ticket = _dbContext.Tickets.Find(dto.TicketId);
            if (ticket == null)
                return NotFound("Ticket Not Found");


            if(string.IsNullOrEmpty(dto.Comment))
                return BadRequest("Comment is Required");

            var comment = new TicketComment
            {
                TicketId = dto.TicketId,
                Comment = dto.Comment,
                CreatedAt = DateTime.Now,
                CreatedBy = dto.CreatedBy
            };

            _dbContext.TicketComments.Add(comment);
            _dbContext.SaveChanges();

            return Ok(comment);
        }
    }
}
