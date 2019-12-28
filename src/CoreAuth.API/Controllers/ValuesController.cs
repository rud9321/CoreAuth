using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoreAuth.API.Controllers
{
    [Route("/api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly DataBaseContext _dataBaseContext;

        public ValuesController(DataBaseContext dataBaseContext) => _dataBaseContext = dataBaseContext;

        public IActionResult Get()
        {
            var result = _dataBaseContext.Student.Select(_ => _.Name).ToArray();
            return result is null ? NotFound() : (IActionResult) Ok(result);
            //return Ok(new[] { "a", "b"});
        }

        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            var result = _dataBaseContext.Student.Where(_ => _.Id.Equals(id)).Select(_ => _.Name);
            if (result is null)
                return NotFound();

            IEnumerable<string> str = result as IEnumerable<string>;
            return Ok(str);
            //return Ok("A");
        }
    }
}
