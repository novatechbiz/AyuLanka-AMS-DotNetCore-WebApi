using AyuLanka.AMS.Data;
using AyuLanka.AMS.DataModels;
using AyuLanka.AMS.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AyuLanka.AMS.Repositories
{
    public class ShiftMasterRepository : IShiftMasterRepository
    {
        private readonly ApplicationDbContext _context;

        public ShiftMasterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ShiftMaster>> GetAllShiftMastersAsync()
        {
            return await _context.ShiftMasters.ToListAsync();
        }
    }
}
