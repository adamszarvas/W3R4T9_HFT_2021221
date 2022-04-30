using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using W3R4T9_HFT_2021221.Logic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace W3R4T9_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PassengerNcController : ControllerBase
    {
        IPassengerLogic logic;

        public PassengerNcController(IPassengerLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<int, double>> AVGAge()
        {
            
            return logic.AveragePassengerAgeByFlights();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<int,int>> LongNames()
        {
            return logic.LongNamesByFlights();
        }
    }
}
