namespace HospitalMS.Web.InputModels.Department
{
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;
    using System.ComponentModel.DataAnnotations;

    public class DepartmentCreateInputModel : IMapTo<DepartmentServiceModel>
    {
        [Required]
        [MinLength(4, ErrorMessage = "The {0} must be at least {1} characters long.")]
        public string Name { get; set; }

        public string Description { get; set; }

        public int IsActive { get; set; }

        [Required]
        public string HospitalName { get; set; }

    }
}
