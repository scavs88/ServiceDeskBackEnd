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
    public class ResolutionController : ControllerBase
    {
        [HttpGet()]
        public List<Resolution> GetResolutions()
        {
            using (ServiceDeskDBContext context = new ServiceDeskDBContext())
            {
                return context.Resolutions.ToList();
            }
        }

        [HttpPost]
        public Resolution AddResultion(string ticketname, string resolution, string closedby)
        {
            using (ServiceDeskDBContext context = new ServiceDeskDBContext())
            {
                Resolution r = new Resolution()
                {
                    TicketName = ticketname,
                    Resolution1 = resolution,
                    ClosedBy = closedby
                };
                context.Resolutions.Add(r);
                context.SaveChanges();
                return r;
            }
        }
    }
}
