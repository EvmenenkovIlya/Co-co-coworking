namespace CoCoCoWorking.DAL.DTO
{
    public class AllRoomAndWorkPlaceBusyOrFreeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? WorkPlaceNumber { get; set; }
        public List<WorkPlaceDto> Workplaces { get; set; } = new List<WorkPlaceDto>();
        public List<RentPriceDto> RentPrices { get; set; } = new List<RentPriceDto>();
        public List<OrderUnitDto> Orderunits { get; set; } = new List<OrderUnitDto>();

        public AllRoomAndWorkPlaceBusyOrFreeDto()
        { 

        }


        public override bool Equals(object? obj)
        {
            bool flag = true;
            if (obj == null || !(obj is AllRoomAndWorkPlaceBusyOrFreeDto))
            {
                flag = false;
            }
            AllRoomAndWorkPlaceBusyOrFreeDto alrDto = (AllRoomAndWorkPlaceBusyOrFreeDto)obj;
            if (alrDto.Id != this.Id ||
                alrDto.Name != this.Name ||
                alrDto.WorkPlaceNumber != this.WorkPlaceNumber)
            {
                flag = false;
            }
            return flag;
        }
    }


}
