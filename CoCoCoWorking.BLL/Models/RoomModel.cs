namespace CoCoCoWorking.BLL.Models
{
    public class RoomModel
    {
        public int Id { get; set; }
        public TypeOfProduct Type { get; set; }
        public string Name { get; set; }
        public int? WorkPlaceNumber { get; set; }
        public RoomModel()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;
            if (obj == null || !(obj is RoomModel))
            {
                flag = false;
            }
            else
            {
                RoomModel rmDto = (RoomModel)obj;
                if (rmDto.Id != this.Id ||
               rmDto.Type != this.Type ||
               rmDto.Name != this.Name ||
               rmDto.WorkPlaceNumber != this.WorkPlaceNumber)

                {
                    flag = false;
                }
            }
            return flag;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
