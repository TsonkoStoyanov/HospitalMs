namespace HospitalMS.Web.ViewModels.Receptionist
{
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;


    public class ReceptionistAllViewModel : IMapFrom<ReceptionistServiceModel>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string HospitalName { get; set; }
    }
}
