﻿using AyuLanka.AMS.Data;
using AyuLanka.AMS.DataModels;
using AyuLanka.AMS.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AyuLanka.AMS.Repositories
{
    public class ShiftChangeDetailRepository : IShiftChangeDetailRepository
    {
        private readonly ApplicationDbContext _context;

        public ShiftChangeDetailRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ShiftChangeDetail> CreateShiftChangeDetailAsync(ShiftChangeDetail ShiftChangeDetail)
        {
            _context.ShiftChangeDetails.Add(ShiftChangeDetail);
            await _context.SaveChangesAsync();
            return ShiftChangeDetail;
        }

        public async Task<IEnumerable<ShiftChangeDetail>> GetAllShiftChangeDetailsAsync()
        {
            return await _context.ShiftChangeDetails
                .Include(c => c.ShiftChangeMaster.Employee)
                .Include(c => c.StaffRoster)
                .Include(c => c.ShiftMasterPre)
                .Include(c => c.ShiftMasterPost)
                .OrderBy(c => c.ShiftChangeMaster.Employee.EmployeeNumber)
                .Where(c => c.IsApproved == false).ToListAsync();
        }

        public async Task<ShiftChangeDetail> GetShiftChangeDetailByDatePreAndRosterAsync(int ShiftPre, int staffRosterId)
        {
            return await _context.ShiftChangeDetails.Where(c => c.ShiftPre == ShiftPre && c.StaffRosterId == staffRosterId)
                .FirstOrDefaultAsync();
        }

        public async Task<ShiftChangeDetail> GetShiftChangeDetailByIdAsync(int id)
        {
            return await _context.ShiftChangeDetails.Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<ShiftChangeDetail> UpdateShiftChangeDetailAsync(ShiftChangeDetail ShiftChangeDetail)
        {
            _context.ShiftChangeDetails.Update(ShiftChangeDetail);
            await _context.SaveChangesAsync();
            return ShiftChangeDetail;
        }
    }
}
