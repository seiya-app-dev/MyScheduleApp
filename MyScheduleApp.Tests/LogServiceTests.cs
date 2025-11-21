using Moq;
using MyScheduleApp.Models;
using MyScheduleApp.Repositories;
using MyScheduleApp.Services;
using Xunit;

namespace MyScheduleApp.Tests
{
    public class LogServiceTests
    {
        [Fact]
        public void AddLog_ReturnsTrue()
        {
            var mockRepo = new Mock<ILogRepository>();
            var service = new LogService(mockRepo.Object);

            var log = new Log
            {
                LogId = 1,
                UserId = 1,
                TargetUserId = 1,
                ActionId = 1,
            };

            mockRepo.Setup(r => r.AddLog(log))
                .Returns(1);

            var result = service.AddLog(log);
            Assert.True(result);
            mockRepo.Verify(r => r.AddLog(log), Times.Once);
        }

        [Fact]
        public void AddLog_RepositoryThrows_ExceptionThrown()
        {
            var mockRepo = new Mock<ILogRepository>();
            var service = new LogService(mockRepo.Object);

            var log = new Log
            {
                LogId = 1,
                UserId = 1,
                TargetUserId = 1,
                ActionId = 1,
            };

            mockRepo.Setup(r => r.AddLog(log))
                .Throws(new Exception("DB Error"));

            Assert.Throws<Exception>(() => service.AddLog(log));
            mockRepo.Verify(r => r.AddLog(log), Times.Once);
        }

        [Fact]
        public void GetLog_ValidLog_ReturnsLogs()
        {
            var mockRepo = new Mock<ILogRepository>();
            var service = new LogService(mockRepo.Object);

            var logs = new List<Log>
            {
                new Log
                {
                 LogId = 1,
                 UserId = 1,
                 TargetUserId = 1,
                 ActionId = 1,
                }                
            };

            mockRepo.Setup(r => r.GetLogs())
                .Returns(logs);
            var result = service.GetLogs();

            Assert.NotNull(result);
            Assert.Equal(logs.Count, result.Count);
            Assert.Equal(logs[0].LogId, result[0].LogId);
            Assert.Equal(logs[0].UserId, result[0].UserId);
            Assert.Equal(logs[0].TargetUserId, result[0].TargetUserId);
            Assert.Equal(logs[0].ActionId, result[0].ActionId);
            mockRepo.Verify(r => r.GetLogs(), Times.Once);
        }

        [Fact]
        public void GetLog_RepositoryThrows_ExceptionThrown()
        {
            var mockRepo = new Mock<ILogRepository>();
            var service = new LogService(mockRepo.Object);

            mockRepo.Setup(r => r.GetLogs())
                .Throws(new Exception("DB Error"));

            Assert.Throws<Exception>(() => service.GetLogs());
            mockRepo.Verify(r => r.GetLogs(), Times.Once);
        }
    }
}
