namespace HospitalMS.Web.InputModels.Patient
{
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PatientCreateFromFirstLoginInputModel : IMapTo<PatientServiceModel>
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
        [StringLength(40, ErrorMessage = "{0} must be between {2} and {1} symbols", MinimumLength = 6)]
        public string Address { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
    }
}
