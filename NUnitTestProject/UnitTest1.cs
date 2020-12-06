using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using Web_Core_Service;
using Web_Data.Model;

namespace NUnitTestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public async Task Create()
        {
             TaskCompletionSource<long> taskCompletion = new TaskCompletionSource<long>();
            taskCompletion.SetResult(2);

            var user = new User { FirstName = "Anil", LastName = "M", City = "Hal" ,PhoneNumber="123456" };
            var mockService = new Mock<IUserService>();
            
             mockService.Setup(x => x.SaveUserDetails(user)).Returns(taskCompletion.Task);

            var userobject= await mockService.Object.SaveUserDetails(user);
            Assert.AreEqual(userobject, 1);
        }

        [Test]
        public async Task Edit()
        {
            TaskCompletionSource<Task> taskCompletion = new TaskCompletionSource<Task>();
            taskCompletion.SetResult(Task.CompletedTask);

            var user = new User {UserId=1, FirstName = "Anil", LastName = "M", City = "Hal", PhoneNumber = "123456" };
            var mockService = new Mock<IUserService>();

            mockService.Setup(x => x.UpdateUserDetails(user)).Returns(taskCompletion.Task);

            await mockService.Object.UpdateUserDetails(user);
            Assert.True(true);
        }
    }
}