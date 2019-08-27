namespace HospitalMS.Data.Models
{
    public class Patient : BaseModel<string>
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Diagnose { get; set; }

        public string HospitalMSUserId { get; set; }
        public virtual HospitalMSUser UserPatient { get; set; }

        public virtual Bed Bed { get; set; }

        public string DepartmentId { get; set; }
        public virtual Department Department { get; set; }


    }
}
