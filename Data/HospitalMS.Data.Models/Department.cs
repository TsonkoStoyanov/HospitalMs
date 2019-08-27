namespace HospitalMS.Data.Models
{
    using System.Collections.Generic;


    public class Department : BaseModel<string>
    {
        public Department()
        {
            this.Rooms = new HashSet<Room>();
            this.Doctors = new HashSet<Doctor>();
            this.Patients = new HashSet<Patient>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }


        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }

        public string HospitalId { get; set; }
        public virtual Hospital Hospital { get; set; }
    }
}