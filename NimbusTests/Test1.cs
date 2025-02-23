using Moq;using Nimbus;
using NimbusTests.Shared;
using System.Net.Sockets;

namespace NimbusTests
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestDbConnection()
        {
            using (var context = new DataContext())
            {
               //Arrange
               var mock = new Mock<DataContext>();
                //Act
                mock.Setup(x => x.DbPath).Returns("Data.db");
                //Assert
            }
        }
        public void TestRepositories()
        {
            //Arrange
            var mock = new Mock<Repository>();
            //Act
            mock.Setup(x => x.GetTruckById(1)).Returns(new TruckEntity());
            //Assert
        }
    }
}
