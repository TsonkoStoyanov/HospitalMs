namespace HospitalMS.Data.Models
{
    public class RoomType : BaseModel<int>
    {
        public string Name { get; set; }

        public decimal PriceForBed { get; set; }
    }
}