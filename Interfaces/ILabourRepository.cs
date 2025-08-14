using zbs_gp_project.Models;

namespace zbs_gp_project.Interfaces
{
    public interface ILabourRepository
    {
        public Task<ICollection<Labour>> GetLaboursAsync(CancellationToken ct);
        public Task<bool> DeleteLabourAsync(string id, CancellationToken ct);
        public Task AddLabourAsync(Labour labour, CancellationToken ct);
        public Task<int> GetUsersLabourCountAsync(CancellationToken ct);
    }
}
