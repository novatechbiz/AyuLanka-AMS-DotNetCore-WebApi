using AyuLanka.AMS.Data;
using AyuLanka.AMS.DataModels;
using AyuLanka.AMS.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AyuLanka.AMS.Repositories
{
    public class EmployementTypeRepository : IEmployementTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployementTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmploymentType>> GetAllEmployementTypesAsync()
        {
            return await _context.EmploymentTypes.ToListAsync();
        }
    }
}
