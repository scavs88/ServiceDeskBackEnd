using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceDesk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookMarkedController : ControllerBase
    {

        [HttpGet()]
        public List<BookMarked> GetAll()
        {
            using (ServiceDeskDBContext context = new ServiceDeskDBContext())
            {
                return context.BookMarkeds.ToList();
            }
        }

        [HttpPost]
        public BookMarked AddBookMarked(string bookmarkedby, bool status, string ticketname, string issue, string openedby)
        {
            using (ServiceDeskDBContext context = new ServiceDeskDBContext())
            {
                BookMarked b = new BookMarked()
                {
                    BookMarkedBy = bookmarkedby,
                    Status = status,
                    TicketName = ticketname,
                    Issue = issue,
                    OpenedBy = openedby
                };
                context.BookMarkeds.Add(b);
                context.SaveChanges();
                return b;
            }
        }


    }
}
