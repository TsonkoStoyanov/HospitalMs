namespace HospitalMS.Services.Models
{
    using HospitalMS.Data.Models;
    using HospitalMS.Services.Mapping;


    public class PatientServiceModel : IMapTo<Patient>
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Diagnose { get; set; }

        public string HospitalMSUserId { get; set; }

        public DepartmentServiceModel Department { get; set; }
    }
}
