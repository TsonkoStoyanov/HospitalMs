namespace HospitalMS.Web.ViewModels.Room
{
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;
    using HospitalMS.Web.ViewModels.Bed;
    using System.Collections.Generic;

    public class RoomAllViewModel : IMapFrom<RoomServiceModel>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string RoomType { get; set; }

        public string Department { get; set; }

        public List<BedViewModel> Beds { get; set; }
    }
}
