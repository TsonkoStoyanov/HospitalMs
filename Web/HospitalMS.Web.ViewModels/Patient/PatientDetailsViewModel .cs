namespace HospitalMS.Web.ViewModels.Patient
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using HospitalMS.Services.Mapping;
    using HospitalMS.Services.Models;

    public class PatientDetailsViewModel : IMapFrom<PatientServiceModel>
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        public bool IsHospitalized { get; set; }

        public string DepartmentName { get; set; }

    }
}
