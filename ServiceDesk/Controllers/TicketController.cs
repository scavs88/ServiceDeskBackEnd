﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceDesk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        [HttpGet()]
        public List<Ticket> GetTickets()
        {
            using (ServiceDeskDBContext context = new ServiceDeskDBContext())
            {
                return context.Tickets.ToList();
            }
        }

        [HttpPost()]
        public Ticket AddTicket(bool status, string ticketName, string issue, string openedBy)
        {

            using (ServiceDeskDBContext context = new ServiceDeskDBContext())
            {
                Ticket ticket = new Ticket()
                {
                    Status = status,
                    TicketName = ticketName,
                    Issue = issue,
                    OpenedBy = openedBy
                };
                context.Tickets.Add(ticket);
                context.SaveChanges();
                return ticket;
            }
        }

        [HttpGet()]
        public Ticket GetTicketByID(int id)
        {
            using (ServiceDeskDBContext context = new ServiceDeskDBContext())
            {
                return context.Tickets.ToList().Find(t => t.Id == id);
            }

        }

        [HttpGet()]
        public Ticket GetTicketByTicketName(string ticketname)
        {
            using (ServiceDeskDBContext context = new ServiceDeskDBContext())
            {
                return context.Tickets.ToList().Find(t => t.TicketName == ticketname);
            }

        }

    }
}
