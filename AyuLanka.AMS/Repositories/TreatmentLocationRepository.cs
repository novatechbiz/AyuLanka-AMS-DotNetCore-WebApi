using AyuLanka.AMS.Data;
using AyuLanka.AMS.DataModels;
using AyuLanka.AMS.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AyuLanka.AMS.Repositories
{
    public class TreatmentLocationRepository : ITreatmentLocationRepository
    {
        private readonly ApplicationDbContext _context;

        public TreatmentLocationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TreatmentLocation>> GetAllTreatmentLocationAsync()
        {
            return await _context.TreatmentLocations
                .Include(t => t.Location)
                .Include(t => t.TreatmentType)
                .ToListAsync();
        }
    }
}
