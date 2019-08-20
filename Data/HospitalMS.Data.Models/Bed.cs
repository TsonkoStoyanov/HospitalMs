namespace HospitalMS.Data.Models
{
    public class Bed : BaseModel<string>
    {
        public int Number { get; set; }

        public bool IsOcupied { get; set; } = false;

        public string RoomId { get; set; }
        public Room Room { get; set; }

    }
}