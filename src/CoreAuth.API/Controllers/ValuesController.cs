using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreAuth.API.Controllers
{
    [Route("/api/[controller]")]
    [Authorize]
    public class ValuesController : Controller
    {
        // private readonly DataBaseContext _dataBaseContext;

        // public ValuesController(DataBaseContext dataBaseContext) => _dataBaseContext = dataBaseContext;

        public IActionResult Get()
        {
            // var result = _dataBaseContext.Student.Select(_ => _.Name).ToArray();
            // return result is null ? NotFound() : (IActionResult) Ok(result);
            return Ok(new[] { "a", "b"});
        }

        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            // var result = _dataBaseContext.Student.Where(_ => _.Id.Equals(id)).Select(_ => _.Name);
            // if (result is null)
            //    return NotFound();
            var reflection = Assembly.GetExecutingAssembly();
            var types = reflection.GetTypes();
            // IEnumerable<string> str = result as IEnumerable<string>;
            return Ok(types.ToArray().Select(_ => _.Name));
            //return Ok("A");
        }
    }
}
