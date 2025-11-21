using Moq;
using MyScheduleApp.Repositories;
using MyScheduleApp.Services;
using Xunit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using AppUser = MyScheduleApp.Models.User;

namespace MyScheduleApp.Tests
{
    public class LoginServiceTests
    {
        [Fact]
        public void GetUser_ValidUser_ReturnsUsers()
        {
           var mockRepo = new Mock<ILoginRepository>();

            var expectedUser = new AppUser
            {
                UserId = 1,
                UserName = "Test",
                PasswordHash = "Test"
            };

            mockRepo.Setup(r => r.GetUser("Test", "Test"))
                .Returns(expectedUser);

            var service = new LoginService(mockRepo.Object);
            var result = service.GetUser("Test", "Test");

            Assert.NotNull(result);
            Assert.Equal(expectedUser.UserId, result.UserId);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void GetUser_InValidUserName_ThrowArgumentException(string userName)
        {
            var mockRepo = new Mock<ILoginRepository>();
            var service = new LoginService(mockRepo.Object);

            Assert.Throws<ArgumentException>(() =>
            service.GetUser(userName, "Test"));

            mockRepo.Verify(r => r.GetUser(userName, "Test"), Times.Once);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void GetUser_InValidPasswordHash_ThrowArgumentException(string password)
        {
            var mockRepo = new Mock<ILoginRepository>();
            var service = new LoginService (mockRepo.Object);

            Assert.Throws<ArgumentException>(() =>
            service.GetUser("Test", password));
            mockRepo.Verify(r => r.GetUser("Test", password), Times.Once);
        }

        [Theory]
        [InlineData("abc")]
        [InlineData("abcdefghijklmnopqrstu")]        

        public void GetUser_InValidUserNameLength_ThrowArgumentException(string userName)
        {
            var mockRepo = new Mock<ILoginRepository>();
            var service = new LoginService(mockRepo.Object);

            Assert.Throws<ArgumentException>(() =>
            service.GetUser(userName, "Test"));
            mockRepo.Verify(r => r.GetUser(userName, "Test"), Times.Once);
        }

        [Fact]
        public void GetUser_InValidUser_Exception()
        {
            var mockRepo = new Mock<ILoginRepository>();

            mockRepo.Setup(r => r.GetUser(It.IsAny<string>(), It.IsAny<string>()))
                .Throws(new Exception());

            var service = new LoginService(mockRepo.Object);

            Assert.Throws<Exception>(() => service.GetUser("Test", "Test"));

            mockRepo.Verify(r => r.GetUser("Test", "Test"), Times.Once());
        }
    }
}