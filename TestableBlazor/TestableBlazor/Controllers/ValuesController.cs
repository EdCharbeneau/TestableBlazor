using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestableBlazor.Client.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestableBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController(IDataService data) : ControllerBase
    {

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            return await data.GetRegions();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<string[]> Get(string id)
        {
            return await data.GetTeamsByRegion(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
