using zbs_gp_project.Models;

namespace zbs_gp_project.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmail(string email, CancellationToken ct = default); // what is CancellationToken //
        Task AddAsync(User user, CancellationToken ct = default);
    }
}
