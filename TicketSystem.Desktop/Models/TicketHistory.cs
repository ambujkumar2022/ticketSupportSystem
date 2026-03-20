using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Desktop.Models
{
    public class TicketHistory
    {
        public int Id { get; set; }

        public int TicketId { get; set; }

        public string Status { get; set; }

        public string Comment { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }  // Username or Admin name
    }
}
