namespace HospitalMS.Web.ViewModels.Receptionist
{
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;


    public class ReceptionistDeleteViewModel : IMapFrom<ReceptionistServiceModel>
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string HospitalName { get; set; }

    }
}
