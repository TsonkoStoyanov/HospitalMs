namespace HospitalMS.Web.InputModels.RoomType
{
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;
    using System.ComponentModel.DataAnnotations;


    public class RoomTypeEditInputModel : IMapTo<RoomTypeServiceModel>, IMapFrom<RoomTypeServiceModel>
    {
        [Required]
        [StringLength(10, ErrorMessage = "{0} must be between {2} and {1} symbols", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Range(1, 200, ErrorMessage = "Price for bed can only be between {1} .. {2}")]
        public decimal PriceForBed { get; set; }
    }
}
