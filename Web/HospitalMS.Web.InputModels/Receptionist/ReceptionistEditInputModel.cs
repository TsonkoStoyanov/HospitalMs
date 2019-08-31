namespace HospitalMS.Web.InputModels.Receptionist
{
    using AutoMapper;
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;
    using System.ComponentModel.DataAnnotations;


    public class ReceptionistEditInputModel : IMapTo<ReceptionistServiceModel>, IMapFrom<ReceptionistServiceModel>
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
        public string HospitalName { get; set; }

    }
}
