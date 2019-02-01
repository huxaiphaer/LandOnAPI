using System;
using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App
{
    public class HotelApiDbContext : DbContext
    {
        public HotelApiDbContext(DbContextOptions options)
          : base(options)
        { }
            public DbSet<RoomEntity> Rooms { get; set; }
            
    }
}
