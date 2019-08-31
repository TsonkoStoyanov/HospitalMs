namespace HospitalMS.Web.ViewModels.User
{
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;



    public class HospitalMSUserViewModel : IMapTo<HospitalMSUserServiceModel>, IMapFrom<HospitalMSUserServiceModel>
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public bool IsFirstLogin { get; set; }
    }
}
