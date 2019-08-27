namespace HospitalMS.Web.ViewModels.Department
{
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;


    public class RoomViewModel : IMapFrom<RoomServiceModel>
    {
        public string Name { get; set; }
    }
}
