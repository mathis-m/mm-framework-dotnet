﻿using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleAspNetCoreSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        // GET: api/<SampleController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SampleController>/5
        [Obsolete("Deprecated.")]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("name/{name}")]
        public string GetByName(string name)
        {
            return "GetByName";
        }


        // POST api/<SampleController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SampleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SampleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
