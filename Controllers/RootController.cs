using System;
using App.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Route("/")]
    [ApiController]
    [ApiVersion("1.0")]
    public class RootController : ControllerBase
    {
        [HttpGet(Name = nameof(GetRoot))]
        [ProducesResponseType(200)]
        public IActionResult GetRoot()
        {
            var response = new RootResponse{
                Self = Link.To(nameof(GetRoot)),  // TODO: URl.Link(nameof(GetRoot),null)
                Rooms = Link.To(nameof(RoomsController.GetRooms)),
                Info = Link.To(nameof(InfoController.GetInfo))
            };
            return Ok(response);
        }
    }

    internal class RootResponse
    {
        public Link Rooms { get; set; }
        public Link Info { get; set; }
        public object Self { get; internal set; }
    }
}
