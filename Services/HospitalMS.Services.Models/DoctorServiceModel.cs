
namespace HospitalMS.Services.Models
{
    using HospitalMS.Data.Models;
    using HospitalMS.Services.Mapping;

    public class DoctorServiceModel : IMapTo<Doctor>, IMapFrom<Doctor>
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string HospitalMSUserId { get; set; }

        public DepartmentServiceModel Department { get; set; }
    }
}
