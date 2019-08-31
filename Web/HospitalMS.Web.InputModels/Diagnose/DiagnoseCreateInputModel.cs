namespace HospitalMS.Web.InputModels.Diagnose
{
    using System.ComponentModel.DataAnnotations;
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;


    public class DiagnoseCreateInputModel : IMapTo<DiagnoseServiceModel>
    {

        [Required]
        [StringLength(100, ErrorMessage = "{0} must be between {2} and {1} symbols", MinimumLength = 6)]
        public string Details { get; set; }
    }
}
