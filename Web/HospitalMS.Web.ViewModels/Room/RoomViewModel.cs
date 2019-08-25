namespace HospitalMS.Web.ViewModels.Room
{
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;


    public class RoomViewModel : IMapFrom<RoomServiceModel>
    {
        public string Name { get; set; }
    }
}
