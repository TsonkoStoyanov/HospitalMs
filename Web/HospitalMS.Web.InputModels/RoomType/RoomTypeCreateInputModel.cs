namespace HospitalMS.Web.InputModels.RoomType
{
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;
    using System.ComponentModel.DataAnnotations;


    public class RoomTypeCreateInputModel : IMapTo<RoomTypeServiceModel>
    {
        [Required]
        [StringLength(10, ErrorMessage = "{0} must be between {2} and {1} symbols", MinimumLength = 3)]
        public string Name { get; set; }
    }
}
