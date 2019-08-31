namespace HospitalMS.Services.Models
{
    using System;
    using HospitalMS.Data.Models;
    using HospitalMS.Services.Mapping;


    public class AppointmentServiceModel : IMapTo<Appointment>, IMapFrom<Appointment>
    {
        public string Id { get; set; }

        public DateTime AppointmentDate { get; set; }

        public string Details { get; set; }

        public bool Status { get; set; }

        public PatientServiceModel Patient { get; set; }

        public DoctorServiceModel Doctor { get; set; }
    }
}