using HospitalMS.Services.Mapping;
using HospitalMS.Services.Models;

namespace HospitalMS.Web.InputModels.Hospital
{
    public class HospitalEditInputModel : IMapTo<HospitalServiceModel>, IMapFrom<HospitalServiceModel>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
