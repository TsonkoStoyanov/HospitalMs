namespace HospitalMS.Data.Models
{
    using System;


    public class Diagnose : BaseModel<string>
    {
        public DateTime Date { get; set; }

        public string Details { get; set; }

        public string PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        public string DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
