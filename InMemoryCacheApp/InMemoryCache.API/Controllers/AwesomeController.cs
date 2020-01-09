using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InMemoryCache.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AwesomeController : ControllerBase
    {
        private readonly IMemoryCache _cache;

        public AwesomeController(IMemoryCache cache)
        {
            _cache = cache;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            throw new NotImplementedException();
        }

        // GET api/values/
        [HttpGet("{key}")]
        public ActionResult<string> Get(string key)
        {
            try
            {
                return _cache.Get<string>(key);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post()
        {
            try
            {
                _cache.Set("Greet", "Hello World");
                return new OkResult();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
