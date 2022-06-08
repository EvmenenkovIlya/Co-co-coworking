namespace CoCoCoWorking.DAL.DTO
{
    public class RoomDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int? WorkPlaceNumber { get; set; }
        public int? RoomCount { get; set; }

        public RoomDto()
        {

        }


        public override bool Equals(object? obj)
        {
            bool flag = true;
            if (obj == null || !(obj is RoomDto))
            {
                flag = false;
            }
            RoomDto rmDto = (RoomDto)obj;
            if (rmDto.Id != this.Id ||
               rmDto.Type != this.Type ||
               rmDto.Name != this.Name ||
               rmDto.WorkPlaceNumber != this.WorkPlaceNumber ||
               rmDto.RoomCount != this.RoomCount)

            {
                flag = false;
            }
            return flag;
        }
    }
}
