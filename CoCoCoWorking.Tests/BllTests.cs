using CoCoCoWorking.BLL;
using Moq;
using CoCoCoWorking;
using CoCoCoWorking.DAL.DTO;
using CoCoCoWorking.Tests.ModelControllerSources;
using CoCoCoWorking.BLL.Models;

namespace CoCoCoWorking.Tests
{
    public class BllTests
    {
        public ModelController _modelController;
        private Mock<IModelController> _modelcontrollerMock;

        [SetUp]
        public void SetUp()
        {
            _modelcontrollerMock = new Mock<IModelController>();
            _modelController = new ModelController(_modelcontrollerMock.Object);
        }

        [TestCaseSource(typeof(GetProductNameTestSource))]
        public void GetProductNameTest(FinanceReportDto report, string expected)
        {
            string actual = _modelController.GetProductName(report);

            Assert.AreEqual(expected, actual);  
        }

        [TestCaseSource(typeof(GetProductCountTestSource))]
        public void GetProductCountTest(FinanceReportDto report, int expected)
        {
            int actual = _modelController.GetProductCount(report);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(GetTypeOfProductRoomDtoTestSource))]
        public void GetTypeOfProductTest(RoomDto room, TypeOfProduct expected)
        {
            TypeOfProduct actual = _modelController.GetTypeOfProduct(room);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(GetTypeOfProductRoomModelTestSource))]
        public void GetTypeOfProductTest(RoomModel room, string expected)
        {
            string actual = _modelController.GetTypeOfProduct(room);

            Assert.AreEqual(expected, actual);
        }

        //GetTypeOfProductForRentPriceModel

        //GetNameForRentPriceModel

        [TestCaseSource(typeof(GetTypeOfPeriodTestSource))]
        public void GetTypeOfPeriodTest(RentPriceDto rentPrice, TypeOfPeriod expected)
        {
            TypeOfPeriod actual = _modelController.GetTypeOfPeriod(rentPrice);

            Assert.AreEqual(expected, actual);
        }
    }
}