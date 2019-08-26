namespace HospitalMS.Web.InputModels.Department
{
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;
    using System.ComponentModel.DataAnnotations;


    public class DepartmentCreateInputModel : IMapTo<DepartmentServiceModel>
    {
        [Required]
        [StringLength(10, ErrorMessage = "{0} must be between {2} and {1} symbols", MinimumLength = 4)]
        public string Name { get; set; }

        public string Description { get; set; }

        public int IsActive { get; set; }

        [Required]
        public string HospitalName { get; set; }

    }
}
