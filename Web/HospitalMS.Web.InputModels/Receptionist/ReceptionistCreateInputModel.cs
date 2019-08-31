namespace HospitalMS.Web.InputModels.Receptionist
{
    using AutoMapper;
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;
    using System.ComponentModel.DataAnnotations;



    public class ReceptionistCreateInputModel : IMapTo<ReceptionistServiceModel>
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "{0} must be between {2} and {1} symbols", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

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
