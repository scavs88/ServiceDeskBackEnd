using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceDesk
{
    public partial class Resolution
    {
        public string TicketName { get; set; }
        public string Resolution1 { get; set; }
        public string ClosedBy { get; set; }

        public virtual Ticket TicketNameNavigation { get; set; }
    }
}
