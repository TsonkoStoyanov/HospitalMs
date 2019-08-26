namespace HospitalMS.Data.Models
{
    public class Doctor : BaseModel<string>
    {

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }


        public string HospitalMSUserId { get; set; }
        public virtual HospitalMSUser UserDoctor { get; set; }

        public string DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
