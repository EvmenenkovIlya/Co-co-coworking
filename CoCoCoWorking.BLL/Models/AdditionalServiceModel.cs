namespace CoCoCoWorking.BLL.Models
{
    public class AdditionalServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Count { get; set; }
        
      public AdditionalServiceModel()
      {

      }
       

       public override bool Equals(object? obj)
       {
            bool flag = false;
            if (obj == null || !(obj is AdditionalServiceModel))
            {
                flag = false;
            }
            else
            {
                AdditionalServiceModel addDto = (AdditionalServiceModel)obj;
                if (addDto.Id != this.Id ||
                    addDto.Name != this.Name)
                {
                    flag = false;
                }
            }
            return flag;
       }



    }
}
