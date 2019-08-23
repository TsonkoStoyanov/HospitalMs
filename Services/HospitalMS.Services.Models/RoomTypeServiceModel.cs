namespace HospitalMS.Services.Models
{
    using HospitalMS.Data.Models;
    using HospitalMS.Services.Mapping;
    public class RoomTypeServiceModel : IMapTo<RoomType>, IMapFrom<RoomType>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
