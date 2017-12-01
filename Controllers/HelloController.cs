using System;
using Microsoft.AspNetCore.Mvc;

namespace HelloAngular
{
    /// <summary>
    /// HelloController
    /// </summary>
    [Route("api/[Controller]")]
    public class HelloController : Controller
    {
        /// <summary>
        /// Greetings
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Greetings() {
            return Ok("Hello from ASP.NET Core Web API.");
        }
    }
}
