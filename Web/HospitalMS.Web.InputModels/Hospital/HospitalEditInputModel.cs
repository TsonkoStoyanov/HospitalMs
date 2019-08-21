using HospitalMS.Services.Mapping;
namespace HospitalMS.Web.InputModels.Hospital
{
    using HospitalMS.Services.Models;
    using System.ComponentModel.DataAnnotations;

    public class HospitalEditInputModel : IMapTo<HospitalServiceModel>, IMapFrom<HospitalServiceModel>
    {
        public string Id { get; set; }

        [Required]
        [StringLength(100,ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
