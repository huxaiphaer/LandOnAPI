using System;
using System.Threading.Tasks;
using App.Models;
using App.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet(Name = nameof(GetRooms))]
        public IActionResult GetRooms()
        {
            throw new NotImplementedException();
        }

        //GET
        [HttpGet("{roomId}", Name =nameof(GetRommById))]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Room>> GetRommById(Guid roomId)
        {
            var room = await _roomService.GetRommAsync(roomId);
            if (room == null) return NotFound();

            return room;
        }
    }
}
