using HospitalMS.Services.Mapping;
using HospitalMS.Data.Models;

namespace HospitalMS.Services.Models
{
    public class HospitalServiceModel : IMapFrom<Hospital>, IMapTo<Hospital>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

    }
}
