using AyuLanka.AMS.Data;
using AyuLanka.AMS.DataModels;
using AyuLanka.AMS.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AyuLanka.AMS.Repositories
{
    public class ShiftChangeMasterRepository : IShiftChangeMasterRepository
    {
        private readonly ApplicationDbContext _context;

        public ShiftChangeMasterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ShiftChangeMaster>> GetAllShiftChangeMastersAsync()
        {
            return await _context.ShiftChangeMasters.ToListAsync();
        }

        public async Task<ShiftChangeMaster> GetShiftChangeMasterByIdAsync(int id)
        {
            return await _context.ShiftChangeMasters.FindAsync(id);
        }

        public async Task<ShiftChangeMaster> AddShiftChangeMasterAsync(ShiftChangeMaster ShiftChangeMaster)
        {
            await _context.ShiftChangeMasters.AddAsync(ShiftChangeMaster);
            await _context.SaveChangesAsync();
            return ShiftChangeMaster;
        }

        public async Task<ShiftChangeMaster> UpdateShiftChangeMasterAsync(ShiftChangeMaster ShiftChangeMaster)
        {
            _context.Entry(ShiftChangeMaster).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return ShiftChangeMaster;
        }

        public async Task DeleteShiftChangeMasterAsync(int id)
        {
            var ShiftChangeMaster = await _context.ShiftChangeMasters.FindAsync(id);
            if (ShiftChangeMaster != null)
            {
                _context.ShiftChangeMasters.Remove(ShiftChangeMaster);
                await _context.SaveChangesAsync();
            }
        }
    }
}
