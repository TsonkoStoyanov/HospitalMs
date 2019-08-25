namespace HospitalMS.Services.Models
{
    using HospitalMS.Data.Models;
    using HospitalMS.Services.Mapping;
    using System.Collections.Generic;


    public class RoomServiceModel :  IMapTo<Room>, IMapFrom<Room>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public RoomTypeServiceModel RoomType { get; set; }

        public DepartmentServiceModel Department { get; set; }

        public List<BedServiceModel> Beds { get; set; }

    }
}
