using Microsoft.EntityFrameworkCore;
using zbs_gp_project.Data;
using zbs_gp_project.Interfaces;
using zbs_gp_project.Models;

namespace zbs_gp_project.Repository
{
    public class LabourRepository : ILabourRepository
    {
        private readonly LabourContext _context;
        private readonly ICurrentUserService _currentUserService;

        public LabourRepository(LabourContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<int> GetUsersLabourCountAsync(CancellationToken ct)
        {
            var currrentUserId = _currentUserService?.UserId;
            return await _context.Labours.Where(l => l.UserId == currrentUserId).CountAsync(ct);
        }

        public async Task AddLabourAsync(Labour labour, CancellationToken ct)
        {
            labour.UserId = _currentUserService.UserId;
             _context.Labours.Add(labour);
            await _context.SaveChangesAsync(ct);

        }

        public async Task<bool> DeleteLabourAsync(string id, CancellationToken ct)
        {
            var currentUserId = _currentUserService.UserId;
            var instanceToRemove = await _context.Labours.FirstOrDefaultAsync(l => l.Id == id && l.UserId == currentUserId);
            
            if (instanceToRemove == null)
            {
                return false;
            }

            _context.Labours.Remove(instanceToRemove);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<ICollection<Labour>> GetLaboursAsync(CancellationToken ct)
        {
            return await _context.Labours
                .AsNoTracking()
                .OrderBy(l => l.Id)
                .Where(l => l.UserId == _currentUserService.UserId)
                .ToListAsync(ct);
        }
    }
}
