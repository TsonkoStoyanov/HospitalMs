namespace HospitalMS.Data.Models
{
    using System.Collections.Generic;


    public class Department : BaseModel<string>
    {
        public Department()
        {
            this.Rooms = new HashSet<Room>();
            this.Users = new HashSet<HospitalMSUser>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<HospitalMSUser> Users { get; set; }

        public string HospitalId { get; set; }
        public virtual Hospital Hospital { get; set; }
    }
}