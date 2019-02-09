using System;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using Microsoft.Extensions.DependencyInjection;

namespace App
{
    public static class SeedData
    {

        public static async Task InitializeAsync(IServiceProvider services)
        {
            await AddTestData(services.GetRequiredService<HotelApiDbContext>());
        }

        public static async Task AddTestData(HotelApiDbContext context)
        {
            if (context.Rooms.Any())
            {
                // Already has Data.
                return;
            }

            context.Rooms.Add(new RoomEntity
            {
                Id = Guid.Parse("4djdj-djdj-djdjfh-iodnnd"),
                Name = "Oxford Suite",
                Rate = 10388

            });

            context.Rooms.Add(new RoomEntity
            {
                Id = Guid.Parse("3H-djdjdjdj-djdjfh-iodnnd"),
                Name = "Driscole Suite",
                Rate = 10388

            });


            await context.SaveChangesAsync();
        }
    }
}
