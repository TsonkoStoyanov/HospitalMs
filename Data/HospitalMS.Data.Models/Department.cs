namespace HospitalMS.Data.Models
{
    using System.Collections.Generic;
    public class Department : BaseModel<string>
    {
        public Department()
        {
            this.Rooms = new List<Room>();
            this.Users = new List<HospitalMSUser>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public List<Room> Rooms { get; set; }
        public List<HospitalMSUser> Users { get; set; }

        public string HospitalId { get; set; }
        public Hospital Hospital { get; set; }
    }
}