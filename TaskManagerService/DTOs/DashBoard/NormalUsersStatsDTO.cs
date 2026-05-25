using TaskManager.DTOs.DashBoard;


//Inheritance  - wants to reuse all the common dashboard properties from DashboardStatsDto instead of rewriting them again
namespace TaskManager.MultiTenant.DTOs.DashBoard
{
    public class NormalUsersStatsDTO: DashboardStatsDto
    {
        public string TaskName { get; set; }
       // public int PendingTasks { get; set; }
    }
}
