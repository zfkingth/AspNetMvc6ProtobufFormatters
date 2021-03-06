﻿using AspNetMvc6Protobuf.Model;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMvc6Protobuf.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values/5
        [HttpGet("{id}")]
        public ProtobufModelDto Get(int id)
        {
            return new ProtobufModelDto() { Id = 1, Name = "HelloWorld", StringValue = "My first MVC 6 Protobuf service" };
        }

        [HttpPost]
        [Route("")]
        public void Post([FromBody]ProtobufModelDto value)
        {
            // Yes the value can be sent as a protobuf item.
            var myValue = value;
        }

    }
}
