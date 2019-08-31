namespace HospitalMS.Services.Models
{
    using HospitalMS.Data.Models;
    using HospitalMS.Services.Mapping;

    public class HospitalMSUserServiceModel : IMapTo<HospitalMSUser>, IMapFrom<HospitalMSUser>
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public bool IsFirstLogin { get; set; }
    }
}
