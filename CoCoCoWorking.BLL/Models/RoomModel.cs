namespace CoCoCoWorking.BLL.Models
{
    public class RoomModel
    {
        public int Id { get; set; }
        public TypeOfProduct Type { get; set; }
        public string Name { get; set; }
        public int? WorkPlaceNumber { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
