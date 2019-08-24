namespace HospitalMS.Web.InputModels.Room
{
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;
    using System.ComponentModel.DataAnnotations;

    public class RoomCreateInputModel : IMapTo<RoomServiceModel>
    {
        [Required]
        [StringLength(10, ErrorMessage = "{0} must be between {2} and {1} symbols", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string RoomType { get; set; }

        [Required]
        public string Department { get; set; }

    }
}
