namespace HospitalMS.Web.ViewModels.Doctor
{
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;

    public class DoctorViewModel : IMapFrom<DoctorServiceModel>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
