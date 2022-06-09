namespace CoCoCoWorking.DAL.DTO
{
    public class AdditionalServiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Count { get; set; }
        public bool IsDeleted { get; set; }


    public AdditionalServiceDto()
    {
       
    }

        public override bool Equals(object? obj)
        {
            bool flag = true;
            if (obj == null || !(obj is AdditionalServiceDto))
            {
                flag = false;
            }
            AdditionalServiceDto addDto = (AdditionalServiceDto)obj;
            if (addDto.Id != this.Id||
                addDto.Name != this.Name||
                addDto.Count != this.Count)
            {
                flag = false;
            }
            return flag;
        }
    }
}


