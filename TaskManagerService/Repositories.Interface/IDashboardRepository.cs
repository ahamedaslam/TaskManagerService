using System.Threading.Tasks;
using TaskManager.DTOs.DashBoard;
using TaskManager.MultiTenant.DTOs.TaskManager;

namespace TaskManager.API.Repositories.Interface
{
    public interface IDashboardRepository
    {
        Task<DashboardStatsDto> GetDashboardStatsAsync(string tenantId, string userId, string role);
    }
}
