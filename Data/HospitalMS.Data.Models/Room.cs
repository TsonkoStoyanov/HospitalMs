
namespace HospitalMS.Data.Models
{
    using System.Collections.Generic;
    public class Room : BaseModel<string>
    {
        public Room()
        {
            this.Beds = new HashSet<Bed>();
        }
        public string Name { get; set; }

        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
        public ICollection<Bed> Beds { get; set; }

    }
}