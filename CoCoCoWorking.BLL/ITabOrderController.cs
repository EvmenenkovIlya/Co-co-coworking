using CoCoCoWorking.BLL.Models;

namespace CoCoCoWorking.BLL
{
    public interface ITabOrderController
    {
        public List<RentPriceModel> SearchRentPricesById(int selectedIndexType, int modelId);
        public decimal GetPriceForCustomer(RentPriceModel model, CustomerModel customer);
        public RentPriceModel GetRequiredRentPrice(List<RentPriceModel> list, int hours);
        public List<DateTime> GetStringBusyDate(int? roomId, int? workplaceId);
        public List<int> SearchFreeForDate(string startDate, string endDate, bool forWorkplace = false);
        public List<int> GetAllWorkplaceInRoom(int id);
        public IEnumerable<DateTime> GetEveryDayInRange(DateTime start, DateTime end);
        public void FillId(OrderUnitModel orderUnit, int indexType, RoomModel room = null, AdditionalServiceModel additionalService = null, WorkPlaceModel workplace = null);


    }
}