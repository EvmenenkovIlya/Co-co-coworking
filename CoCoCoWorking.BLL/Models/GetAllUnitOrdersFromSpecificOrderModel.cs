namespace CoCoCoWorking.BLL.Models
{
    public class GetAllUnitOrdersFromSpecificOrderModel
    {
        public int Id { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Name { get; set; }
        public int? Number { get; set; }

        public GetAllUnitOrdersFromSpecificOrderModel()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;
            if (obj == null || !(obj is GetAllUnitOrdersFromSpecificOrderModel))
            {
                flag = false;
            }
            else
            {
                GetAllUnitOrdersFromSpecificOrderModel gaouDto = (GetAllUnitOrdersFromSpecificOrderModel)obj;
                if (gaouDto.Id != this.Id ||
                    gaouDto.StartDate != this.StartDate ||
                    gaouDto.EndDate != this.EndDate ||
                    gaouDto.Name != this.Name ||
                    gaouDto.Number != this.Number)
                {
                    flag = false;
                }
            }
            return flag;
        }
    }
}
