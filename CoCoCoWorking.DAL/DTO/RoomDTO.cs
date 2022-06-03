namespace CoCoCoWorking.DAL.DTO
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }       
        public int? WorkPlaceNumber { get; set; }
        public int? RoomCount { get; set; }

        public override string ToString()
        {
            return $"Id={Id} Name={Name} WorkPlaceNumber={WorkPlaceNumber}";
        }
    }
}
