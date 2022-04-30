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
    public class PassengerController : ControllerBase
    {
        IPassengerLogic logic;
        IHubContext<SignalRHub> hub;

        public PassengerController(IPassengerLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        // GET: api/<PassengerController>
        [HttpGet]
        public IEnumerable<Passenger> Get()
        {
            return logic.ReadAll();
        }

        // GET api/<PassengerController>/5
        [HttpGet("{id}")]
        public Passenger Get(int id)
        {
            return logic.Read(id);

        }

        // POST api/<PassengerController>
        [HttpPost]
        public void Post([FromBody] Passenger value)
        {
            logic.Create(value);
            this.hub.Clients.All.SendAsync("PassengerCreated", value);
        }

        // PUT api/<PassengerController>/5
        [HttpPut]
        public void Put([FromBody] Passenger value)
        {
            logic.Update(value);
            this.hub.Clients.All.SendAsync("PassengerUpdated", value);
        }

        // DELETE api/<PassengerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var passengerToDelete = this.logic.Read(id);
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("PassengerDeleted", passengerToDelete);
        }
    }
}
