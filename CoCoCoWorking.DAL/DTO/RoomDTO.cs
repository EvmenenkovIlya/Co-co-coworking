namespace CoCoCoWorking.DAL.DTO
{
    public class RoomDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }       
        public int? WorkPlaceNumber { get; set; }
        public int? RoomCount { get; set; }
    }
}
