namespace HospitalMS.Web.ViewModels.Diagnose
{
    using AutoMapper;
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;
    using HospitalMS.Web.ViewModels.Doctor;
    using System;

    public class PatientDiagnoseViewModel : IMapFrom<DiagnoseServiceModel>
    {
        public string Details { get; set; }

        public DateTime Date { get; set; }

        public DoctorViewModel Doctor { get; set; }

    }

}


