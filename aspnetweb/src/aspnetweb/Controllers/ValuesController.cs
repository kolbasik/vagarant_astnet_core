using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace aspnetweb.Controllers
{
    [Route("api/[controller]")]
    public sealed class ValuesController : Controller
    {
        private readonly List<string> source;

        public ValuesController(IOptions<Options> options)
        {
            var config = options.Value;
            source = config.Values ?? Enumerable.Range(1, 3).Select(i => $"value_{i}").ToList();
        }

        // GET api/values
        [HttpGet, ResponseCache(CacheProfileName = "Never")]
        public IEnumerable<string> Get()
        {
            return source.AsReadOnly();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var element = source.ElementAtOrDefault(id);
            if (element != null)
                return Ok(element);
            return NotFound();
        }

        // POST api/values
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void Post([FromBody] string value)
        {
            source.Add(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public void Put(int id, [FromBody] string value)
        {
            source[id] = value;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public void Delete(int id)
        {
            source[id] = null;
        }

        public sealed class Options
        {
            public List<string> Values { get; set; }
        }
    }
}