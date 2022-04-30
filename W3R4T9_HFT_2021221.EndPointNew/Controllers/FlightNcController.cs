using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using W3R4T9_HFT_2021221.Logic;
using W3R4T9_HFT_2021221.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace W3R4T9_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class FlightNcController : ControllerBase
    {
        IFlightLogic logic;

        public FlightNcController(IFlightLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<FlightNcController>
        [HttpGet]
        public IEnumerable<KeyValuePair<int,double>> AVGTicket()
        {
            return logic.AverageTicketPriceByAirlines();
            
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> Fullness()
        {
            return logic.FlightsFullness();
        }

        [HttpGet]
        public IEnumerable<Flight> SeatOrder()
        {
            return logic.FlightsOrderedBySeats();
        }


    }
}
