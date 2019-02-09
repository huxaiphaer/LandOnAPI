using System;
using System.Threading.Tasks;
using App.Models;

namespace App.Service
{
    public interface IRoomService
    {
        Task<Room> GetRommAsync(Guid Id);
    }
}
