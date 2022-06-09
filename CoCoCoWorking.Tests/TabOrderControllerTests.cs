using CoCoCoWorking.BLL;
using Moq;
using CoCoCoWorking.DAL.DTO;
using CoCoCoWorking.Tests;
using CoCoCoWorking;

namespace CoCoCoWorking.Tests
{
    public class TabOrderControllerTests
    {
        public TabOrderController _tabOrderController;
        private Mock<ITabOrderController> _tabOrderControllerMock;


        public void SentUp()
        {
            _tabOrderControllerMock = new Mock<ITabOrderController>();
            _tabOrderController = new TabOrderController(_tabOrderControllerMock.Object);
        }

        //[TestCaseSource(typeof(SearchRentPricesById))]
    }

}
