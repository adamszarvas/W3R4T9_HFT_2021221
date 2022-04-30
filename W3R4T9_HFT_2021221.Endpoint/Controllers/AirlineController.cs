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
    public class AirlineController : ControllerBase
    {
        IAirlineLogic logic;

        public AirlineController(IAirlineLogic logic)
        {
            this.logic = logic;
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
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        public void Put([FromBody] Airline value)
        {
            logic.Update(value);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}
