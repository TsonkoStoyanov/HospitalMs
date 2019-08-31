namespace HospitalMS.Services.Models
{
    using System;
    using AutoMapper;
    using HospitalMS.Data.Models;
    using HospitalMS.Services.Mapping;


    public class DiagnoseServiceModel : IMapTo<Diagnose>, IMapFrom<Diagnose>
    {
        public string Id { get; set; }

        public DateTime Date { get; set; }

        public string Details { get; set; }

        public PatientServiceModel PatientName { get; set; }

        public DoctorServiceModel DoctorName { get; set; }

    }
}