namespace HospitalMS.Web.ViewModels.Diagnose
{
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;
    using System;

    public class PatientDiagnoseViewModel : IMapFrom<DiagnoseServiceModel>
    {
        public string Details { get; set; }

        public DateTime Date { get; set; }
    }
}

