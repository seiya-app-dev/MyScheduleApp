using Moq;
using MyScheduleApp.Models;
using MyScheduleApp.Repositories;
using MyScheduleApp.Services;
using Xunit;

namespace MyScheduleApp.Tests
{
    public class ScheduleServiceTests
    {
        [Fact]
        public void GetSchedules_ReturnsList()
        {
            var mockRepo = new Mock<IScheduleRepository>();
            var expected = new List<Schedule>()
            {
                new Schedule{ScheduleId = 1, UserId = 1, Date = new DateTime(2024, 1, 1), Details = "Test"}
            };                                    

            mockRepo.Setup(r => r.GetSchedules(1, 2024, 1))
                .Returns(expected);

            var service = new ScheduleService(mockRepo.Object);

            var result = service.GetSchedules(1, 2024, 1);

            Assert.NotNull(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void AddSchedule_ValidSchedule_CallsRepositoryOnece()
        {
            var mockRepo = new Mock<IScheduleRepository>();
            var service = new ScheduleService(mockRepo.Object);

            service.AddSchedule(1, new DateTime(2024, 1, 1), "Test");

            mockRepo.Verify(r => r.AddSchedule(1, new DateTime(2024, 1, 1), "Test"), Times.Once);

        }

        [Fact]
        public void DeleteSchedule_ValidScedule_CallRepositoryOnce()
        {
            var mockRepo = new Mock<IScheduleRepository>();
            var service = new ScheduleService(mockRepo.Object);

            service.DeleteSchedule(1, new DateTime(2024, 1, 1));

            mockRepo.Verify(r => r.DeleteSchedule(1, new DateTime(2024, 1, 1)), Times.Once);
        }

        [Fact]
        public void RestoreSchedule_ValidSchedule_CallRepositoryOnce()
        {
            var mockRepo = new Mock<IScheduleRepository>();
            var service = new ScheduleService(mockRepo.Object);

            service.RestoreSchedule(1, new DateTime(2024,1, 1));

            mockRepo.Verify(r => r.RestoreSchedule(1, new DateTime(2024, 1, 1)), Times.Once);
        }
    }
}
