namespace CoCoCoWorking.DAL.DTO
{
    public class AllRoomsWithPriceWithPeriodRentaHDto
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public List<RoomDto> Rooms { get; set; }
        public List<RentPriceDto> Rentprices { get; set; } = new List<RentPriceDto>();

        public AllRoomsWithPriceWithPeriodRentaHDto()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;
            if (obj == null || !(obj is AllRoomsWithPriceWithPeriodRentaHDto))
            {
                flag = false;
            }
            AllRoomsWithPriceWithPeriodRentaHDto allrwpDto = (AllRoomsWithPriceWithPeriodRentaHDto)obj;
            if (allrwpDto.StartDate != this.StartDate ||
                allrwpDto.EndDate != this.EndDate)
            {
                flag = false;
            }
            return flag;
        }
    }
}
