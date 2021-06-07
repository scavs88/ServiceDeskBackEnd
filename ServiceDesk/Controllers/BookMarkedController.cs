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



        [HttpGet("bookmarkedBy")]
        public List<BookMarked> GetAllByUserId(string bookmarkedBy)
        {
            using (ServiceDeskDBContext context = new ServiceDeskDBContext())
            {
                List<BookMarked> list = new List<BookMarked>();

                list = context.BookMarkeds.Where(b => b.BookMarkedBy.ToLower() == bookmarkedBy.ToLower()).ToList();
                return list;
            }
        }



        [HttpPost]
        public BookMarked AddBookMarked(string bookmarkedby, int ticketId)
        {
            using (ServiceDeskDBContext context = new ServiceDeskDBContext())
            {
                BookMarked b = new BookMarked()
                {
                    BookMarkedBy = bookmarkedby,
                    TicketId = ticketId
                };
                context.BookMarkeds.Add(b);
                context.SaveChanges();
                return b;
            }
        }


    }
}
