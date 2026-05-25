using Microsoft.EntityFrameworkCore;
using TaskManager.API.Repositories.Interface;
using TaskManager.DBContext;
using TaskManager.DTOs.DashBoard;
using TaskManager.Interface;
using TaskManager.Models;
using TaskManager.MultiTenant.DTOs.DashBoard;

namespace TaskManager.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly AuthDBContext _dbContext;


        public DashboardRepository(AuthDBContext authDBContext)
        {
            _dbContext = authDBContext;
        }
       
        public async Task<DashboardStatsDto> GetDashboardStatsAsync(
            string tenantId,
            string userId,
            string role)
        {
            IQueryable<TaskItem> query = _dbContext.TaskItems
                .Where(t => t.TenantId == tenantId);

            // Use camelCase for local variables
            var taskName = await query
                .Select(t => t.Title)
                .FirstOrDefaultAsync();

            var totalTasks = await query.CountAsync();

            var completedTasks = await query
                .CountAsync(t => t.IsCompleted);

            var pendingTasks = totalTasks - completedTasks;

            var overdueTasks = await query
                .CountAsync(t =>
                    !t.IsCompleted &&
                    t.DueTime != null &&
                    t.DueTime < DateTime.UtcNow);

            var highPriority = await query
                .CountAsync(t => t.Priority == TaskPriority.High);

            // If normal user, return a NormalUsersStatsDTO (inherits DashboardStatsDto)
            if (role != "Admin")
            {
                return new NormalUsersStatsDTO
                {
                    TaskName = taskName,
                    PendingTasks = pendingTasks,
                };
            }

            // Admin gets the general DashboardStatsDto
            return new DashboardStatsDto
            {
                TotalTasks = totalTasks,
                CompletedTasks = completedTasks,
                PendingTasks = pendingTasks,
                OverDue = overdueTasks,
                HighPriority = highPriority
            };
        }


        //public async Task<TaskAnalyticsDTO> GetTaskAnalytics(string tenantId)
        //{
        //    var today = DateTime.UtcNow;
        //
        //    var completed = await _dbContext.TaskItems.CountAsync(t => t.TenantId == tenantId && t.IsCompleted);
        //
        //    var pending = await _dbContext.TaskItems.CountAsync(t => t.TenantId == tenantId && !t.IsCompleted);
        //
        //
        //
        //    return new TaskAnalyticsDTO
        //    {
        //        Completed = completed,
        //        Pending = pending,
        //        Overdue = overdue,
        //        HighPriority = highPriority
        //    };
        //}

    }
}

