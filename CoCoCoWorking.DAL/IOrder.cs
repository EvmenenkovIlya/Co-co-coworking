using CoCoCoWorking.DAL.DTO;

namespace CoCoCoWorking.DAL
{
    public interface Interface
    {
        public List<RentPriceDto> SearchRentPricesById(int selectedIndexType, int modelId);
        public decimal GetPriceForCustomer(RentPriceDto model, CustomersWithOrdersDto customer);
        public RentPriceDto GetRequiredRentPrice(List<RentPriceDto> list, int hours);
        public List<DateTime> GetStringBusyDate(int? roomId, int? workplaceId);
        public List<int> SearchFreeForDate(string startDate, string endDate, bool forWorkplace = false);
        public List<int> GetAllWorkplaceInRoom(int id);
        public IEnumerable<DateTime> GetEveryDayInRange(DateTime start, DateTime end);
        public void FillId(OrderUnitDto orderUnit, int indexType, RoomDto room = null, AdditionalServiceDto additionalService = null, WorkPlaceDto workplace = null);

    }
}
