using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Desktop.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }

        public string Priority { get; set; }   // Low, Medium, High

        public string Status { get; set; }     // Open, InProgress, Closed

        public DateTime CreatedDate { get; set; }

        public string AssignedTo { get; set; }

        public int CreatedBy { get; set; }     // UserId
    }
}
