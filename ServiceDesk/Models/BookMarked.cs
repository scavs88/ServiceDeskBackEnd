using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceDesk
{
    public partial class BookMarked
    {
        public string BookMarkedBy { get; set; }
        public int Id { get; set; }

        public virtual Ticket IdNavigation { get; set; }
    }
}
