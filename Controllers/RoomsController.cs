using System;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Route("")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
      
        [HttpGet(Name = nameof(GetRooms))]
        public IActionResult GetRooms()
        {
            throw new NotImplementedException();
        }
    }
}
