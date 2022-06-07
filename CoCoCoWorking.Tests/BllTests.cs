using CoCoCoWorking.BLL;
using Moq;
using CoCoCoWorking;

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
            //_modelController = new ModelController(_modelcontrollerMock.Object) ;
        }

    }
}