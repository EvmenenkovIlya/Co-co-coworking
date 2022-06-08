using CoCoCoWorking.BLL;
using Moq;
using CoCoCoWorking;
using CoCoCoWorking.DAL.DTO;
using CoCoCoWorking.Tests.ModelControllerSources;

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
            _modelController = new ModelController();
        }

        [TestCaseSource(typeof(GetProductNameTestSource))]
        public void GetProductNameTest(FinanceReportDto report, string expected)
        {
            string actual = _modelController.GetProductName(report);

            Assert.AreEqual(expected, actual);  
        } 
    }
}