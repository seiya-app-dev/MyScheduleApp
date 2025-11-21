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
            Assert.Equal(expected.Count, result.Count);
            Assert.Equal(expected[0].ScheduleId, result[0].ScheduleId);
            Assert.Equal(expected[0].UserId, result[0].UserId);
            Assert.Equal(expected[0].Date, result[0].Date);
            Assert.Equal(expected[0].Details, result[0].Details);
        }

        [Fact]
        public void GetSchedules_RepositoryThrows_ExceptionThrown()
        {
            var mockRepo = new Mock<IScheduleRepository>();
            var service =new ScheduleService(mockRepo.Object);

            mockRepo.Setup(r => r.GetSchedules(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Throws(new Exception("DB Error"));
            Assert.Throws<Exception>(() => service.GetSchedules(1, 2024, 1));

            mockRepo.Verify(r => r.GetSchedules(1, 2024, 1), Times.Once);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        public void GetShcheules_InvalidParameters_ThrowsArgumentException(int year, int month)
        {
            var mockRepo = new Mock<IScheduleRepository>();
            var service = new ScheduleService(mockRepo.Object);

            Assert.Throws<ArgumentException>(() => service.GetSchedules(1, year, month));

            mockRepo.Verify(r => r.GetSchedules(1, year, month), Times.Never);
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

        public void AddSchedule_RepositoryThrows_ExceptionThrown()
        {
            var mockRepo = new Mock<IScheduleRepository>();
            var service = new ScheduleService(mockRepo.Object);
            var date = new DateTime(2024, 1, 1);

            mockRepo.Setup(r => r.AddSchedule(1, date,"Test"))
                .Throws(new Exception("DB Error"));

            Assert.Throws<Exception>( () => service.AddSchedule(1, date, "Test"));
            mockRepo.Verify(r => r.AddSchedule(1, date, "Test"), Times.Once);
        }

        [Fact]
        public void DeleteSchedule_ValidSchedule_CallRepositoryOnce()
        {
            var mockRepo = new Mock<IScheduleRepository>();
            var service = new ScheduleService(mockRepo.Object);

            service.DeleteSchedule(1, new DateTime(2024, 1, 1));

            mockRepo.Verify(r => r.DeleteSchedule(1, new DateTime(2024, 1, 1)), Times.Once);
        }

        [Fact]
        public void DeleteSchedule_RepositoryThrows_ExceptionThrown()
        {
            var mockRepo = new Mock<IScheduleRepository>();
            var service = new ScheduleService(mockRepo.Object);
            var date = new DateTime(2024, 1, 1);

            mockRepo.Setup(r => r.DeleteSchedule(1, date))
                .Throws(new Exception("DB Error"));

            Assert.Throws<Exception>(() => service.DeleteSchedule(1, date));
            mockRepo.Verify(r => r.DeleteSchedule(1, date), Times.Once);

        }

        [Fact]
        public void RestoreSchedule_ValidSchedule_CallRepositoryOnce()
        {
            var mockRepo = new Mock<IScheduleRepository>();
            var service = new ScheduleService(mockRepo.Object);

            service.RestoreSchedule(1, new DateTime(2024,1, 1));

            mockRepo.Verify(r => r.RestoreSchedule(1, new DateTime(2024, 1, 1)), Times.Once);
        }

        [Fact]
        public void RestoreSchedule_RepositoryThrows_ExceptionThrown()
        {
            var mockRepo = new Mock<IScheduleRepository>();
            var service = new ScheduleService(mockRepo.Object);
            var date = new DateTime(2024, 1, 1);

            mockRepo.Setup(r => r.RestoreSchedule(1, date))
                .Throws(new Exception("DB Error"));

            Assert.Throws<Exception>(() => service.RestoreSchedule(1, date));
            mockRepo.Verify(r => r.RestoreSchedule(1, date), Times.Once);
        }
    }
}
