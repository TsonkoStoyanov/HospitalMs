namespace HospitalMS.Data.Models
{
    using System;


    public class Appointment : BaseModel<string>
    {
        public DateTime AppointmentDate { get; set; }

        public string Details { get; set; }

        public bool IsComplete { get; set; }

        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
