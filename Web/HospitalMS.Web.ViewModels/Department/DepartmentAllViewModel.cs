namespace HospitalMS.Web.ViewModels.Department
{
    using HospitalMS.Services.Models;
    using HospitalMS.Services.Mapping;
    using System.Collections.Generic;
    using HospitalMS.Web.ViewModels.Patient;
    using HospitalMS.Web.ViewModels.Doctor;


    public class DepartmentAllViewModel : IMapFrom<DepartmentServiceModel>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public string HospitalName { get; set; }

        public List<RoomViewModel> Rooms { get; set; }

        public List<PatientViewModel> Patients { get; set; }

        public List<DoctorViewModel> Doctors { get; set; }
    }
}
