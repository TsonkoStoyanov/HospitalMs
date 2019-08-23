namespace HospitalMS.Services.Models
{
    using HospitalMS.Data.Models;
    using HospitalMS.Services.Mapping;

    public class RoomServiceModel : IMapFrom<Room>, IMapTo<Room>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public RoomTypeServiceModel RoomType { get; set; }

        public int Beds { get; set; }

    }
}
