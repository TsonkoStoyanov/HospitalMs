namespace HospitalMS.Web.InputModels.Room
{
    using AutoMapper;
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;
    using System.ComponentModel.DataAnnotations;


    public class RoomCreateInputModel : IMapTo<RoomServiceModel>, IHaveCustomMappings
    {
        [Required]
        [StringLength(10, ErrorMessage = "{0} must be between {2} and {1} symbols", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string RoomType { get; set; }

        [Required]
        public string Department { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
               .CreateMap<RoomCreateInputModel, RoomServiceModel>()
               .ForMember(destination => destination.RoomType,
                           opts => opts.MapFrom(origin => new RoomTypeServiceModel { Name = origin.RoomType }))
               .ForMember(destination => destination.Department,
                           opts => opts.MapFrom(origin => new DepartmentServiceModel { Name = origin.Department }));
        }
    }
}
