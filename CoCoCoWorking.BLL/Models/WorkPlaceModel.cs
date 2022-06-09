namespace CoCoCoWorking.BLL.Models
{
    public class WorkPlaceModel
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int? Number { get; set; }

        public WorkPlaceModel()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;
            if (obj == null || !(obj is WorkPlaceModel))
            {
                flag = false;
            }
            WorkPlaceModel wpDto = (WorkPlaceModel)obj;
            if (wpDto.Id != this.Id ||
               wpDto.RoomId != this.RoomId ||
               wpDto.Number != this.Number)

            {
                flag = false;
            }
            return flag;
        }

        public override string ToString()
        {
            return Number.ToString();
        }
    }
}
