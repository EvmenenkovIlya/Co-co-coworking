using CoCoCoWorking.BLL;
using Moq;
using CoCoCoWorking;
using CoCoCoWorking.DAL.DTO;
using CoCoCoWorking.Tests.ModelControllerSources;
using CoCoCoWorking.BLL.Models;
using CoCoCoWorking.DAL;
using NUnit.Framework;

namespace CoCoCoWorking.Tests
{
    public class ModelControllerTests
    {
        public ModelController _modelController;
        

        [SetUp]
        public void SetUp()
        {
            _modelController = new ModelController();
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