
using Moq;
using System.Text;
using WpfApplication.Services;
using WpfApplication.ViewModels;


namespace WpfApplication.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var mock = new Mock<SoldierViewModel>();

            // Act
            mock.Object.LoadSoldiers();

            // Assert
            mock.Verify(x => x.LoadSoldiers(), Times.Once);
        }


        [TestMethod]
        public void TestMethod_GetAllSoldiers()
        {
            // Arrange
            var mock = new Mock<SoldierService>();

            // Act
            mock.Object.GetAllSoldiers();

            // Assert
            mock.Verify(x => x.GetAllSoldiers(), Times.Once);

        }

        [TestMethod]
        public void TestMethod_UpdateSoldierPositions()
        {
            // Arrange
            var mock = new Mock<SoldierViewModel>();
            var sender = new object();
            var eventArgs = EventArgs.Empty;

            // Act
            mock.Object.UpdateSoldierPositions(sender, eventArgs);

            // Assert
            mock.Verify(x => x.UpdateSoldierPositions(sender, eventArgs), Times.Once);
        }
    }
}