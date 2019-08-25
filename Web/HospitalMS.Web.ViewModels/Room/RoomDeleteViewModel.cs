namespace HospitalMS.Web.ViewModels.Room
{
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;
    using HospitalMS.Web.ViewModels.Bed;
    using System.Collections.Generic;


    public class RoomDeleteViewModel : IMapFrom<RoomServiceModel>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string RoomTypeName { get; set; }

        public string DepartmentName { get; set; }

        public List<BedViewModel> Beds { get; set; }
    }
}
