using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using W3R4T9_HFT_2021221.EndPointNew.Services;
using W3R4T9_HFT_2021221.Logic;
using W3R4T9_HFT_2021221.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace W3R4T9_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        IHubContext<SignalRHub> hub;
        IFlightLogic logic;

        public FlightController(IFlightLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("FlightCreated", value);
        }

        // PUT api/<FlightController>/5
        [HttpPut]
        public void Put([FromBody] Flight value)
        {
            logic.Update(value);
            this.hub.Clients.All.SendAsync("FlightUpdated", value);

        }

        // DELETE api/<FlightController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var flightToDelete = this.logic.Read(id);
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("FlightDeleted", flightToDelete);
        }
    }
}
