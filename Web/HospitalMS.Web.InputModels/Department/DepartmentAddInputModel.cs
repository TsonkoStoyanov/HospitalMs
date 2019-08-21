namespace HospitalMS.Web.InputModels.Department
{
    using System.ComponentModel.DataAnnotations;

    public class DepartmentAddInputModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public string Hospital { get; set; }

    }
}
