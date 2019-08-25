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
        public virtual RoomType RoomType { get; set; }

        public string DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public virtual ICollection<Bed> Beds { get; set; }

    }
}