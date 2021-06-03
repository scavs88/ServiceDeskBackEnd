using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceDesk
{
    public partial class Ticket
    {
        public Ticket()
        {
            Resolutions = new HashSet<Resolution>();
        }

        public int Id { get; set; }
        public bool? Status { get; set; }
        public string TicketName { get; set; }
        public string Issue { get; set; }
        public string OpenedBy { get; set; }

        public virtual ICollection<Resolution> Resolutions { get; set; }
    }
}
