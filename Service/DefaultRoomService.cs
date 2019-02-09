using System;
using System.Threading.Tasks;
using App.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Service
{
    public class DefaultRoomService : IRoomService
    {
        private readonly HotelApiDbContext _context;
        private readonly IMapper _mapper;

        public DefaultRoomService(HotelApiDbContext context,
         IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Room> GetRommAsync(Guid id)
        {
            var entity = await _context.Rooms
            .SingleOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                return null;
            }

            return _mapper.Map<Room>(entity);

        }
    }
}
