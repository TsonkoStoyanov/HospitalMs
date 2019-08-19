namespace HospitalMS.Data.Models
{
    using System.Collections.Generic;
    public class Departament
    {

        public Departament()
        {
            this.Rooms = new HashSet<Room>();
            this.Users = new HashSet<HospitalMSUser>();
        }

        public string Id { get; set; }

        public string Name { get; set; }


        public ICollection<Room> Rooms { get; set; }
        public ICollection<HospitalMSUser> Users { get; set; }

    }
}