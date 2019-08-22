namespace HospitalMS.Web.InputModels.Department
{
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;
    using System.ComponentModel.DataAnnotations;

    public class DepartmentEditInputModel : IMapTo<DepartmentServiceModel>, IMapFrom<DepartmentServiceModel>
    {
    
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        public string Name { get; set; }

        public string Description { get; set; }

        public int IsActive { get; set; }

        [Required]
        public string HospitalName { get; set; }
    }
}