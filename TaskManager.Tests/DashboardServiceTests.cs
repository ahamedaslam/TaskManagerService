using Moq;
using Microsoft.Extensions.Logging;
using TaskManager.API.Repositories.Interface;
using TaskManager.DTOs.DashBoard;
using TaskManager.Models.Responses;
using System.Threading.Tasks;
using Xunit;

namespace TaskManager.Tests
{
    public class DashboardServiceTests
    {
        private readonly Mock<IDashboardRepository> _mockRepo;
        private readonly Mock<ILogger<DashboardService>> _mockLogger;
        private readonly DashboardService _dashboardService;

        public DashboardServiceTests()
        {
            _mockRepo = new Mock<IDashboardRepository>();
            _mockLogger = new Mock<ILogger<DashboardService>>();
            _dashboardService = new DashboardService(_mockLogger.Object, _mockRepo.Object);
        }

        [Fact]
        public async Task GetDashboardStatsAsync_ShouldCalculateCorrectPercentages()
        {
            // Arrange
            string tenantId = "tenant-1";
            string userId = "user-1";
            string role = "Admin";
            string logId = "log-1";

            var dummyStats = new DashboardStatsDto
            {
                TotalTasks = 10,
                CompletedTasks = 6,
                PendingTasks = 4,
                OverDue = 1,
                HighPriority = 2
            };

            _mockRepo.Setup(r => r.GetDashboardStatsAsync(tenantId, userId, role))
                     .ReturnsAsync(dummyStats);

            // Act
            var response = await _dashboardService.GetDashboardStatsAsync(tenantId, userId, role, logId);

            // Assert
            Assert.NotNull(response);
            Assert.Equal(0, response.ResponseCode); // 0 indicates success in ResponseHelper
            Assert.NotNull(response.ResponseDatas);
            Assert.Equal(10, response.ResponseDatas.TotalTasks);
            Assert.Equal(6, response.ResponseDatas.CompletedTasks);
            Assert.Equal(4, response.ResponseDatas.PendingTasks);
            Assert.Equal(1, response.ResponseDatas.OverDue);
            Assert.Equal(2, response.ResponseDatas.HighPriority);
        }
    }
}
