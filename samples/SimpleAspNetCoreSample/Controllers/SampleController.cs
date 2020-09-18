using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleAspNetCoreSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private static List<string> _values = new List<string> { "value1", "value2" };

        [HttpGet]
        public IEnumerable<string> Get() => _values;

        [HttpGet("{index}")]
        public ActionResult<string> Get(int index)
        {
            var strings = _values.ToArray();

            if (index >= strings.Length || index < 0)
            {
                return BadRequest("index not in range");
            }

            return strings[index];
        }


        [HttpPost]
        public void Post([FromBody] Guid value)
        {
            _values.Add(value.ToString());
        }

        [HttpPut("{index}")]
        public IActionResult Put(int index, [FromBody] string value)
        {
            var strings = _values.ToArray();

            if (index >= strings.Length || index < 0)
            {
                return BadRequest("index not in range");
            }

            strings[index] = value;
            _values = strings.ToList();

            return NoContent();
        }

        [Obsolete]
        [HttpDelete("{index}")]
        public IActionResult Delete(int index)
        {
            if (index >= _values.Count || index < 0)
            {
                return BadRequest("index not in range");
            }

            _values.RemoveAt(index);

            return NoContent();
        }

        [HttpDelete]
        public void Delete([FromBody] MatchQuery deleteQuery)
        {
            var regex = new Regex(deleteQuery.RegexMatch);
            _values.RemoveAll(x => regex.IsMatch(x));
        }
    }

    public class MatchQuery
    {
        [Required] [NotNull] public string RegexMatch { get; set; }
    }
}