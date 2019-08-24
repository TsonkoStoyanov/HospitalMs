namespace HospitalMS.Data.Models
{
    public class Bed : BaseModel<int>
    {
        public int Number { get; set; }
        public bool IsOcupied { get; set; } = false;

        public decimal Price { get; set; }

        public string RoomId { get; set; }
        public Room Room { get; set; }

        public string HospitalMSUserId { get; set; }

        public HospitalMSUser Patient { get; set; }

    }
}