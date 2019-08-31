namespace HospitalMS.Services.Models
{
    using System;
    using HospitalMS.Data.Models;
    using HospitalMS.Services.Mapping;


    public class DiagnoseServiceModel : IMapTo<Diagnose>, IMapFrom<Diagnose>
    {
        public string Id { get; set; }

        public DateTime Date { get; set; }

        public string Details { get; set; }

        public virtual PatientServiceModel Patient { get; set; }

        public virtual DoctorServiceModel Doctor { get; set; }
    }
}