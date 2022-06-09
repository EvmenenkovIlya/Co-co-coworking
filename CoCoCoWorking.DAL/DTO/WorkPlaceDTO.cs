namespace CoCoCoWorking.DAL.DTO
{
    public class WorkPlaceDto
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int? Number { get; set; }
        public int? WorkplaceCount { get; set; }

        public WorkPlaceDto()
        {

        }


        public override bool Equals(object? obj)
        {
            bool flag = true;
            if (obj == null || !(obj is WorkPlaceDto))
            {
                flag = false;
            }
            WorkPlaceDto wpDto = (WorkPlaceDto)obj;
            if (wpDto.Id != this.Id ||
               wpDto.RoomId!=this.RoomId||
               wpDto.Number!=this.Number||
               wpDto.WorkplaceCount!=this.WorkplaceCount)

            {
                flag = false;
            }
            return flag;
        }
    }
}
