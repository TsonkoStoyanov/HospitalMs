namespace HospitalMS.Services.Models
{
    using HospitalMS.Data.Models;
    using HospitalMS.Services.Mapping;


    public class BedServiceModel : IMapTo<Bed>, IMapFrom<Bed>
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public bool IsOcupied { get; set; } = false;

        public bool IsDeleted { get; set; }

        public RoomServiceModel Room { get; set; }

        public PatientServiceModel Patient { get; set; }

    }
}
