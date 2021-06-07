using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceDesk
{
    public partial class BookMarked
    {
        public int? TicketId { get; set; }
        public string BookMarkedBy { get; set; }
        public int Id { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}
