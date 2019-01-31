using System;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Route("/")]
    [ApiController]
    public class RootController : ControllerBase
    {
       [HttpGet(Name = nameof(GetRoot)]
       public IActionResult GetRoot()
        {
            var response = new { href = Url.Link(nameof(GetRoot), null};
            return Ok();
        }
    }
}
