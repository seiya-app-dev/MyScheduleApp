using Microsoft.VisualBasic.Logging;
using Moq;
using MyScheduleApp.Models;
using MyScheduleApp.Repositories;
using MyScheduleApp.Services;
using Xunit;

namespace MyScheduleApp.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public void GetUsers_ReturnsUsers()
        {
            var mockRepo = new Mock<IUserRepository>();
            var service = new UserService(mockRepo.Object);

            var expectedUsers = new List<User>
            {
                new User { UserId = 1, FullName = "Test", PasswordHash = "Test" }
            };

            mockRepo.Setup(r => r.GetUserList())
                .Returns(expectedUsers);

            var result = service.GetUsers();
            Assert.NotNull(result);
            Assert.Equal(expectedUsers.Count, result.Count);
            Assert.Equal(expectedUsers[0].UserId, result[0].UserId);
            Assert.Equal(expectedUsers[0].FullName, result[0].FullName);
            Assert.Equal(expectedUsers[0].PasswordHash, result[0].PasswordHash);

        }

        [Fact]
        public void GetUser_RepositoryThrows_ExceptionThrown()
        {
            var mockRepo = new Mock<IUserRepository>();
            var service = new UserService(mockRepo.Object);

            mockRepo.Setup(r => r.GetUserList())
                .Throws(new Exception("DB Error"));

            Assert.Throws<Exception>(() => service.GetUsers());
            mockRepo.Verify(r => r.GetUserList(), Times.Once);
        }

        [Fact]
        public void AddUser_ValidUser_ReturnsTrue()
        {
            var mockRepo = new Mock<IUserRepository>();
            var service = new UserService(mockRepo.Object);

            var user = new User
            {
                UserId = 1,
                FullName = "Test",
                PasswordHash = "Test"
            };

            mockRepo.Setup(r => r.AddUser(user))
                .Returns(1);
            var result = service.AddUser(user);
            Assert.True(result);
            mockRepo.Verify(r => r.AddUser(user), Times.Once);
        }

        [Fact]
        public void AddUser_RepositoryThrows_ExceptionThrown()
        {
            var mockRepo = new Mock<IUserRepository>();
            var service = new UserService(mockRepo.Object);

            var user = new User
            {
                UserId = 1,
                FullName = "Test",
                PasswordHash = "Test"
            };

            mockRepo.Setup(r => r.AddUser(user))
                .Throws(new Exception("DB Error"));

            Assert.Throws<Exception>(() => service.GetUsers());
            mockRepo.Verify(r => r.AddUser(user), Times.Once);
        }

        [Fact]
        public void GetUserById_ReturnsUsers()
        {
            var mockRepo = new Mock<IUserRepository>();
            var service = new UserService(mockRepo.Object);

            var user = new User
            {
                UserId = 1,
                FullName = "Test",
                PasswordHash = "Test"
            };

            mockRepo.Setup(r => r.GetUserById(1))
                .Returns(user);
                        
            var result = service.GetUserById(1);

            Assert.NotNull(result);
            Assert.Equal(user.UserId, result.UserId);
            Assert.Equal(user.FullName, result.FullName);
            Assert.Equal(user.PasswordHash, result.PasswordHash);

            mockRepo.Verify(r => r.GetUserById(1), Times.Once);
        }

        [Fact]
        public void GetUserById_RepositoryThrows_ExceptionThrown()
        {
            var mockRepo = new Mock<IUserRepository>();
            var service = new UserService(mockRepo.Object);

            int userId = 1;

            mockRepo.Setup(r => r.GetUserById(userId))
                .Throws(new Exception("DB Error"));

            Assert.Throws<Exception>(() => service.GetUserById(userId));

            mockRepo.Verify(r => r.GetUserById(userId), Times.Once);
        }


        [Fact]
        public void UpdateUser_ValidUser_ReturnsTrue()
        {
            var mockRepo = new Mock<IUserRepository>();
            var service = new UserService(mockRepo.Object);

            var user = new User
            {
                UserId = 1,
                FullName = "Test",
                PasswordHash = "Test"
            };

            mockRepo.Setup(r => r.UpdateUser(user))
                .Returns(1);

            var result = service.UpdateUser(user);
            Assert.True(result);
            mockRepo.Verify(r => r.UpdateUser(user), Times.Once);
        }

        [Fact]
        public void UpdateUser_RepositoryThrows_ExceptionThrown()
        {
            var mockRepo = new Mock<IUserRepository>();
            var service = new UserService(mockRepo.Object);

            var user = new User
            {
                UserId = 1,
                FullName = "Test",
                PasswordHash = "Test"
            };

            mockRepo.Setup(r => r.UpdateUser(user))
                .Throws(new Exception("DB Error"));

            Assert.Throws<Exception>(() => service.UpdateUser(user));
            mockRepo.Verify((r => r.UpdateUser(user)), Times.Once);
        }
    }
}
