namespace HospitalMS.Web.ViewModels.Hospital
{
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;


    public class HospitalDetailsViewModel : IMapFrom<HospitalServiceModel>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
