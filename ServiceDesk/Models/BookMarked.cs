using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceDesk
{
    public partial class BookMarked
    {
        public string BookMarkedBy { get; set; }
        public int Id { get; set; }
        public bool? Status { get; set; }
        public string TicketName { get; set; }
        public string Issue { get; set; }
        public string OpenedBy { get; set; }
    }
}
