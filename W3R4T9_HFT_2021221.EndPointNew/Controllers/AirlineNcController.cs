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
    public class AirlineNcController : ControllerBase
    {
        IAirlineLogic logic;

        public AirlineNcController(IAirlineLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<StatController>
        [HttpGet]
        public IEnumerable<KeyValuePair<string,int>> Get()
        {
            return logic.HugeFlightsByAirlines();
        }

        
    }
}
