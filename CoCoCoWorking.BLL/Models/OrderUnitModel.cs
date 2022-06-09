namespace CoCoCoWorking.BLL.Models
{
    public class OrderUnitModel
    {
        public int Id { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int? RoomId { get; set; }
        public int? WorkPlaceId { get; set; }
        public int? WorkPlaceInRoomId { get; set; }
        public int? AdditionalServiceId { get; set; }
        public int OrderId { get; set; }
        public decimal OrderUnitCost { get; set; }

        public string TypeForUi { get; set; }
        public string NameOfficeForUi { get; set; }
        public string NumberWorkplaceForUi { get; set; }

        public OrderUnitModel()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;
            if (obj == null || !(obj is OrderUnitModel))
            {
                flag = false;
            }
            else
            {
                OrderUnitModel ouDto = (OrderUnitModel)obj;
                if (ouDto.Id != this.Id ||
                    ouDto.StartDate != this.StartDate ||
                    ouDto.EndDate != this.EndDate ||
                    ouDto.RoomId != this.RoomId ||
                    ouDto.WorkPlaceId != this.WorkPlaceId ||
                    ouDto.WorkPlaceInRoomId != this.WorkPlaceInRoomId ||
                    ouDto.AdditionalServiceId != this.AdditionalServiceId ||
                    ouDto.OrderId != this.OrderId ||
                    ouDto.OrderUnitCost != this.OrderUnitCost)
                {
                    flag = false;
                }
            }
            return flag;
        }
    }
}
