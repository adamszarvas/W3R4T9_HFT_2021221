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
    public class AirlineController : ControllerBase
    {
        IAirlineLogic logic;
        IHubContext<SignalRHub> hub;

        public AirlineController(IAirlineLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Airline> Get()
        {
            return logic.ReadAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Airline Get(int id)
        {
            return logic.Read(id);
            
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Airline value)
        {
            logic.Create(value);
            this.hub.Clients.All.SendAsync("AirlineCreated", value);
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        public void Put([FromBody] Airline value)
        {
            logic.Update(value);
            this.hub.Clients.All.SendAsync("AirlineUpdated", value);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var airlineToDelete = this.logic.Read(id);
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("AirlineDeleted", airlineToDelete);
        }
    }
}
