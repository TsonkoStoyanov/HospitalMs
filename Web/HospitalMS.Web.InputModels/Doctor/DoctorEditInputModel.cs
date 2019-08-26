namespace HospitalMS.Web.InputModels.Doctor
{
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;
    using System.ComponentModel.DataAnnotations;


    public class DoctorEditInputModel : IMapTo<DoctorServiceModel>, IMapFrom<DoctorServiceModel>
    {

        [Required]
        [StringLength(20, ErrorMessage = "{0} must be between {2} and {1} symbols", MinimumLength = 4)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "{0} must be between {2} and {1} symbols", MinimumLength = 4)]
        public string LastName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "{0} must be between {2} and {1} symbols", MinimumLength = 6)]
        public string PhoneNumber { get; set; }

        [Required]
        public string Department { get; set; }
    }
}
