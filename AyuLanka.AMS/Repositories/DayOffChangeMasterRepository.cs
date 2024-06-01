using AyuLanka.AMS.Data;
using AyuLanka.AMS.DataModels;
using AyuLanka.AMS.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AyuLanka.AMS.Repositories
{
    public class DayOffChangeMasterRepository : IDayOffChangeMasterRepository
    {
        private readonly ApplicationDbContext _context;

        public DayOffChangeMasterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DayOffChangeMaster>> GetAllDayOffChangeMastersAsync()
        {
            return await _context.DayOffChangeMasters.ToListAsync();
        }

        public async Task<DayOffChangeMaster> GetDayOffChangeMasterByIdAsync(int id)
        {
            return await _context.DayOffChangeMasters.FindAsync(id);
        }

        public async Task<DayOffChangeMaster> AddDayOffChangeMasterAsync(DayOffChangeMaster dayOffChangeMaster)
        {
            await _context.DayOffChangeMasters.AddAsync(dayOffChangeMaster);
            await _context.SaveChangesAsync();
            return dayOffChangeMaster;
        }

        public async Task<DayOffChangeMaster> UpdateDayOffChangeMasterAsync(DayOffChangeMaster dayOffChangeMaster)
        {
            _context.Entry(dayOffChangeMaster).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return dayOffChangeMaster;
        }

        public async Task DeleteDayOffChangeMasterAsync(int id)
        {
            var DayOffChangeMaster = await _context.DayOffChangeMasters.FindAsync(id);
            if (DayOffChangeMaster != null)
            {
                _context.DayOffChangeMasters.Remove(DayOffChangeMaster);
                await _context.SaveChangesAsync();
            }
        }
    }
}
