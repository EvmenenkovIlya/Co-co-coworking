namespace CoCoCoWorking.BLL.Models
{
    public class RentPriceModel
    {
        public int Id { get; set; }
        public int? RoomId { get; set; }
        public int? WorkPlaceInRoomId { get; set; }
        public int? AdditionalServiceId { get; set; }
        public int Hours { get; set; }
        public decimal RegularPrice { get; set; }
        public decimal? ResidentPrice { get; set; }
        public decimal? FixedPrice { get; set; }
    }
}
