using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestableBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "AE", "AM", "BI", "BJ", "BN", "BQ", "BR", "BS", "BW", "BY", "CA", "CD", "CH", "CL", "CM", "CN", "DE", "DJ", "ER", "ET", "GE", "GH", "GL", "GT", "GY", "HN", "HT", "HU", "ID", "IN", "IQ", "JO", "KW", "LA", "LB", "LR", "LT", "LU", "LY", "MC", "MD", "MU", "NA", "NG", "NI", "OM", "PK", "PL", "QA", "SB", "SD", "SH", "SK", "SN", "SO", "SR", "SS", "SV", "SY", "SZ", "TD", "TJ", "TL", "US", "UY", "UZ", "WS", "YE", "ZA", "ZW" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string[] Get(string id)
        {
            return new string[] { $"Red {id}", $"Green {id}", $"Blue {id}" };
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
