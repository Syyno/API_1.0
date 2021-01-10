using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;

namespace Project.Controllers.v2
{
    [ApiController]
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IDatabase _database;

        public HomeController(IDatabase database)
        {
            _database = database;
        }

        //[HttpGet("index")]
        //public ActionResult<string> IndexRedis()
        //{
        //    var cs = "127.0.0.1:6379";
        //    var redis = ConnectionMultiplexer.Connect(cs);
        //    var db = redis.GetDatabase();
        //    db.StringSet("anotherkey", "running docker into a container!");
        //    return db.StringGet("anotherkey").ToString();
        //}

        [HttpGet("Get")]
        public string Get([FromQuery] string key)
        {
            return _database.StringGet(key);
        }

        [HttpPost("Post")]
        public void Post([FromBody] Pair keyValue)
        {
            _database.StringSet(keyValue.Key, keyValue.Value);
        }
    }

    public class Pair
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
