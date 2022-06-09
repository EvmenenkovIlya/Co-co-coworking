using CoCoCoWorking.BLL;
using Moq;
using CoCoCoWorking;
using CoCoCoWorking.DAL.DTO;
using CoCoCoWorking.Tests.ModelControllerSources;
using CoCoCoWorking.BLL.Models;
using CoCoCoWorking.DAL;
using CoCoCoWorking.DAL.Interfaces;
using NUnit.Framework;

namespace CoCoCoWorking.Tests
{
    public class BllTests
    {
        public ModelController _modelController;
        private Mock<IModelController> _modelcontrollerMock;

        public FinanceReportManager _financeReportManager;
        private Mock<IFinanceReportManager> _financeReportManagerMock;

        [SetUp]
        public void SetUp()
        {
            _modelcontrollerMock = new Mock<IModelController>();
            _modelController = new ModelController(_modelcontrollerMock.Object);

            _financeReportManagerMock = new Mock<IFinanceReportManager>();
            _financeReportManager = new FinanceReportManager(_financeReportManagerMock.Object);
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

        //[TestCaseSource(typeof(GetTypeOfPeriodTestSource))]
        //public void GetTypeOfPeriodTest(RentPriceDto rentPrice, TypeOfPeriod expected)
        //{
        //    TypeOfPeriod actual = _modelController.GetTypeOfPeriod(rentPrice);

        //    Assert.AreEqual(expected, actual);
        //}

        /*[TestCaseSource(typeof(GetFinanceReportModelsTestSource))]
        public void GetFinanceReportModelsTest
            (
                DateTime startDate,
                DateTime endDate,
                List<FinanceReportDto> expectedFinanceReportDto,
                List<FinanceReportModel> expectedFinanceReportModel
            )
        {
            _financeReportManagerMock.Setup(f => f.GetFinanceReport(startDate, endDate)).Returns(expectedFinanceReportDto).Verifiable(); ;

            List<FinanceReportModel> actualFinanceReportModel = _modelController.GetFinanceReportModels(startDate, endDate);

            Assert.AreEqual(expectedFinanceReportModel, actualFinanceReportModel);

            _financeReportManagerMock.Verify();
        }*/

        [TestCaseSource(typeof(GetCustomerWithTheMatchedNumberIsReturnedTestSource))]
        public void GetCustomerWithTheMatchedNumberIsReturnedTest(string pathOfNumber, List<CustomerModel> listCustomers, List<CustomerModel> expected)
        {
            List<CustomerModel> actual = _modelController.GetCustomerWithTheMatchedNumberIsReturned(pathOfNumber, listCustomers);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(IsRegularTestSource))]
        public void IsRegularTest(CustomersWithOrdersDto customer, bool expected)
        {
            bool actual = _modelController.IsRegular(customer);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(IsSubscribeTestSource))]
        public void IsSubscribeTest(CustomersWithOrdersDto customer, bool expected)
        {
            bool actual = _modelController.IsSubscribe(customer);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(GetLastDateTestSource))]
        public void GetLastDateTest(CustomersWithOrdersDto customer, string expected)
        {
            string actual = _modelController.GetLastDate(customer);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(GetSumOrderUnitsTestSource))]
        public void GetSumOrderUnitsTest(List<OrderUnitModel> orderUnits, decimal expected)
        {
            decimal actual = _modelController.GetSumOrderUnits(orderUnits);

            Assert.AreEqual(expected, actual);
        }
    }
}