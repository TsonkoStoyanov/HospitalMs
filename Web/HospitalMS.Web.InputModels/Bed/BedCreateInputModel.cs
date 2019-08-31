namespace HospitalMS.Web.InputModels.Bed
{
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;
    using System.ComponentModel.DataAnnotations;

    public class BedAddInputModel : IMapTo<BedServiceModel>
    {
        [Required]
        [Range(1, 10, ErrorMessage = "Bed {0} can only be between {1} .. {2}")]
        public int Number { get; set; }
    }
}
