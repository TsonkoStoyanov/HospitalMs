namespace HospitalMS.Data.Models
{
    using System;
    using System.Collections.Generic;


    public class Patient : BaseModel<string>
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
            Diagnoses = new HashSet<Diagnose>();
            Invoices = new HashSet<Invoice>();
        }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public string Address { get; set; }

        public bool IsHospitalized { get; set; }

        public DateTime? DateOfAcceptance { get; set; }

        public DateTime? DateOfDischarge { get; set; }

        public string HospitalMSUserId { get; set; }
        public virtual HospitalMSUser UserPatient { get; set; }

        public virtual Bed Bed { get; set; }

        public string DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Diagnose> Diagnoses { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
