using Microsoft.EntityFrameworkCore;
using zbs_gp_project.Data;
using zbs_gp_project.Interfaces;
using zbs_gp_project.Models;

namespace zbs_gp_project.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly LabourContext _db;
        public UserRepository(LabourContext db)
        { _db = db; }

        public Task<User?> GetUserByEmail(string email, CancellationToken ct = default)
        {
            return _db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email, ct);
        }

        public async Task AddAsync(User user, CancellationToken ct = default)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync(ct);
        }
    }
}
