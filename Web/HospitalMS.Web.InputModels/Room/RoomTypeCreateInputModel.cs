namespace HospitalMS.Web.InputModels.Room
{
    using System.ComponentModel.DataAnnotations;
    public class RoomTypeCreateInputModel
    {
        [Required]
        [StringLength(10, ErrorMessage = "{0} must be between {2} and {1} symbols", MinimumLength = 3)]
        public string Name { get; set; }
    }
}
