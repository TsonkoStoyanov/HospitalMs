namespace HospitalMS.Services.Models
{
    using HospitalMS.Data.Models;
    using HospitalMS.Services.Mapping;
    using System.Collections.Generic;

    public class DepartmentServiceModel : IMapTo<Department>, IMapFrom<Department>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public string HospitalName { get; set; }

        public List<RoomServiceModel> Rooms { get; set; }

        public List<DoctorServiceModel> Doctors { get; set; }

        public List<PatientServiceModel> Patients { get; set; }
    }
}
