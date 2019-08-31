namespace HospitalMS.Web.InputModels.Patient
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;


    public class PatientEditInputModel : IMapTo<PatientServiceModel>, IMapFrom<PatientServiceModel>,IHaveCustomMappings
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

        [Required]
        public string DepartmentName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
               .CreateMap<PatientEditInputModel, PatientServiceModel>()
               .ForMember(destination => destination.Department,
                           opts => opts.MapFrom(origin => new DepartmentServiceModel { Name = origin.DepartmentName }));
        }
    }
}
