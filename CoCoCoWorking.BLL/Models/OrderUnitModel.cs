namespace CoCoCoWorking.BLL.Models
{
    public class OrderUnitModel
    {
        public int Id { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int? RoomId { get; set; }
        public int? WorkPlaceId { get; set; }
        public int? WorkPlaceInRoomId { get; set; }
        public int? AdditionalServiceId { get; set; }
        public int OrderId { get; set; }
        public decimal OrderUnitCost { get; set; }

        public string TypeForUi { get; set; }
        public string NameOfficeForUi { get; set; }
        public string NumberWorkplaceForUi { get; set; }
    }
}
