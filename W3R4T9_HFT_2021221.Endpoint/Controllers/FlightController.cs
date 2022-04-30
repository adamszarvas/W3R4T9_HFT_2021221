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
    [Route("[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {

        IFlightLogic logic;

        public FlightController(IFlightLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<FlightController>
        [HttpGet]
        public IEnumerable<Flight> Get()
        {
            return logic.ReadAll();
        }

        // GET api/<FlightController>/5
        [HttpGet("{id}")]
        public Flight Get(int id)
        {
            return logic.Read(id);
        }

        // POST api/<FlightController>
        [HttpPost]
        public void Post([FromBody] Flight value)
        {
            logic.Create(value);
        }

        // PUT api/<FlightController>/5
        [HttpPut]
        public void Put([FromBody] Flight value)
        {
            logic.Update(value);

        }

        // DELETE api/<FlightController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}
