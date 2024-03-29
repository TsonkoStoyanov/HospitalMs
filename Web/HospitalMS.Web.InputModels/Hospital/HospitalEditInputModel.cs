﻿namespace HospitalMS.Web.InputModels.Hospital
{
    using HospitalMS.Services.Models;
    using HospitalMS.Services.Mapping;
    using System.ComponentModel.DataAnnotations;


    public class HospitalEditInputModel : IMapTo<HospitalServiceModel>, IMapFrom<HospitalServiceModel>
    {
        public string Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "{0} must be between {2} and {1} symbols", MinimumLength = 4)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "{0} must be between {2} and {1} symbols", MinimumLength = 4)]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
