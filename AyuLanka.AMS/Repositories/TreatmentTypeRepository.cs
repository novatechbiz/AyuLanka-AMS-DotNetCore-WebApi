using AyuLanka.AMS.Data;
using AyuLanka.AMS.DataModels;
using AyuLanka.AMS.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AyuLanka.AMS.Repositories
{
    public class TreatmentTypeRepository : ITreatmentTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public TreatmentTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TreatmentType>> GetAllTreatmentTypesAsync()
        {
            return await _context.TreatmentTypes.Where(a => a.IsActive).ToListAsync();
        }

        public async Task<IEnumerable<TreatmentType>> GetAllTreatmentTypesByLocationAsync(int locationId)
        {
            // Query the join table and then select only the TreatmentTypes
            var treatmentTypes = await _context.TreatmentLocations
                .Where(tl => tl.LocationId == locationId)  // Filter by LocationId
                .Select(tl => tl.TreatmentType)            // Project only the TreatmentType
                .Distinct()                                // Ensure there are no duplicates
                .ToListAsync();

            return treatmentTypes;
        }
    }
}
