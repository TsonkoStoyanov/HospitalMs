namespace HospitalMS.Services.Models
{
    using HospitalMS.Services.Mapping;
    using HospitalMS.Data.Models;
    public class HospitalServiceModel : IMapTo<Hospital>, IMapFrom<Hospital>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

    }
}
