namespace CoCoCoWorking.BLL.Models
{
    public class RentPriceModel
    {
        public int Id { get; set; }
        public int? RoomId { get; set; }
        public int? WorkPlaceInRoomId { get; set; }
        public int? AdditionalServiceId { get; set; }
        public TypeOfProduct Type { get; set; }
        public string Name { get; set; }
        public TypeOfPeriod PeriodType { get; set; }
        public decimal RegularPrice { get; set; }
        public decimal? ResidentPrice { get; set; }
        public decimal? FixedPrice { get; set; }

        public RentPriceModel()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;
            if (obj == null || !(obj is RentPriceModel))
            {
                flag = false;
            }
            else
            {
                RentPriceModel rpDto = (RentPriceModel)obj;
                if (rpDto.Id != this.Id ||
               rpDto.RoomId != this.RoomId ||
               rpDto.WorkPlaceInRoomId != this.WorkPlaceInRoomId ||
               rpDto.AdditionalServiceId != this.AdditionalServiceId ||
               rpDto.Type != this.Type ||
               rpDto.Name != this.Name ||
               rpDto.PeriodType != this.PeriodType ||
               rpDto.RegularPrice != this.RegularPrice ||
               rpDto.ResidentPrice != this.ResidentPrice ||
               rpDto.FixedPrice != this.FixedPrice
               )
                {
                    flag = false;
                }
            }
            return flag;
        }
    }
}
