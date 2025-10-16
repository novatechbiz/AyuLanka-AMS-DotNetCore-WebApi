using AyuLanka.AMS.Data;
using AyuLanka.AMS.DataModels;
using AyuLanka.AMS.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AyuLanka.AMS.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext _context;

        public LocationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Location> GetLocationByLocationIdAsync(int locationId)
        {
            return await _context.Locations
                .Where(p => p.Id == locationId)
                .FirstOrDefaultAsync() ?? new Location();
        }

        public async Task<IEnumerable<Location>> GetAllLocationAsync()
        {
            return await _context.Locations
                .OrderBy(p => p.IsTreatmentLocation)
                .ToListAsync();
        }

        public async Task<IEnumerable<Location>> GetPrimeCareLocationAsync()
        {
            return await _context.Locations.Where(p => p.LocationTypeId == 1 && p.IsTreatmentLocation == true).ToListAsync();
        }

        public async Task<IEnumerable<Location>> GetEliteCareLocationAsync()
        {
            return await _context.Locations.Where(p => p.LocationTypeId == 2 && p.IsTreatmentLocation == true).ToListAsync();
        }

        public async Task<Location> GetPrimeCareLocationByNameAsync(string locationName)
        {
            return await _context.Locations
                .Where(p => p.Name == locationName)
                .FirstOrDefaultAsync();
        }
    }
}
