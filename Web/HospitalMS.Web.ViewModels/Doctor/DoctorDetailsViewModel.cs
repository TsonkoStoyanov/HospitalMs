namespace HospitalMS.Web.ViewModels.Doctor
{
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;


    public class DoctorDetailsViewModel : IMapFrom<DoctorServiceModel>
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string DepartmentName { get; set; }

    }
}
